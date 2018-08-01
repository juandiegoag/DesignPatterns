using DesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    class Bridge
    {
        public Bridge()
        {
            Dog DogAnimal = new Dog("Rufus", new DogActions());
            DogAnimal.DoSound();
            DogAnimal.PrintName();
        }

    }

    abstract class Animal
    {
        protected AnimalActions AnimalActions { get; set; }
        public virtual void DoSound()
        {
            AnimalActions.DoSound();
        }
    }

    abstract class AnimalActions
    {
        public virtual void DoSound()
        {
            Console.WriteLine("Base Sound Implementation");
        }

        public virtual void PrintName(string Name) {
            Console.WriteLine("My name is {0}", Name);
        }

    }


    class DogActions : AnimalActions
    {
        public override void DoSound()
        {
            Console.WriteLine("Bark");            
        }

        public override void PrintName(string Name)
        {
            base.PrintName(Name.ToUpper());
        }

    }

    class Meow : AnimalActions
    {
        public override void DoSound()
        {
            Console.WriteLine("Meow");
        }
    }

    class Moo: AnimalActions
    {
        public override void DoSound()
        {
            Console.WriteLine("Moo");
        }
    }

    class Dog : Animal
    {
        private string Name {get; set;}
        public Dog(string name, AnimalActions AnA)
        {
            AnimalActions = AnA;
            Name = name;
        }

        public override void DoSound()
        {
            AnimalActions.DoSound();
        }

        public void PrintName()
        {
            AnimalActions.PrintName(Name);
        }

        
    }

    class Cat : Animal
    {
        public override void DoSound()
        {
            AnimalActions.DoSound();
        }

    }

    class Cow : Animal
    {
        public override void DoSound()
        {
            AnimalActions.DoSound();
        }

    }


}
