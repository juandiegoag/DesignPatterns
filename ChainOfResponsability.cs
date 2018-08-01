using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsabilityPattern
{
    class ChainOfResponsability
    {
        public ChainOfResponsability()
        {
            Sell sell = new Sell();
            sell.Department = "Electronics";
            sell.Price = 12345;

            ElectronicsHandler electronics = new ElectronicsHandler();
            ClothsHandler cloths = new ClothsHandler();
            HardwareHandler hardware = new HardwareHandler();

            electronics.next = cloths;
            cloths.next = hardware;

            electronics.HandleRequest(sell);
        }
    }

    abstract class ShopHandler
    {
        public ShopHandler()
        {
            next = null;
        }

        public virtual void HandleRequest(Sell sell)
        {
            Console.WriteLine("No further chain to check");
        }
        public ShopHandler next;
    }

    public class Sell
    {
        public string Department { get; set; }
        public int Price { get; set; }
    }

    class ElectronicsHandler : ShopHandler
    {
        
        public override void HandleRequest(Sell sell)
        {
            if (sell.Department.Equals("Electronics"))
            {
                Console.WriteLine("Handled the {0} sale", sell.Price);
            } else
            {
                if (next != null)
                    next.HandleRequest(sell);
            }
        }
    }

    class ClothsHandler : ShopHandler
    {
        
        public override void HandleRequest(Sell sell)
        {
            if (sell.Department.Equals("Cloths"))
            {
                Console.WriteLine("Handled the {0} sale", sell.Price);
            } else
            {
                if (next != null)
                    next.HandleRequest(sell);
            }
        }
    }

    class HardwareHandler : ShopHandler
    {
        
        public override void HandleRequest(Sell sell)
        {
            if (sell.Department.Equals("Hardware"))
            {
                Console.WriteLine("Handled the {0} sale", sell.Price);
            } else
            {
                if (next != null)
                {
                    next.HandleRequest(sell);
                } else
                {
                    Console.WriteLine("Chain not implemented this far");
                }
            }
        }
    }
}
