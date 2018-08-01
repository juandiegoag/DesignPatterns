using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Builder
    {
        public Builder()
        {
            PlantCreator PlantBuilder = new PlantCreator(new WatermelonBuilder());
            PlantBuilder.CreatePlant();
            PlantBuilder.GetPlant();
        }
    }

    class Plant
    {
        public string flower { get; set; }
        public string stem { get; set; }
        public string roots { get; set; }
        public string fruit { get; set; }
    }

    class PlantCreator
    {
        private PlantBuilder _plantBuilder;

        public PlantCreator(PlantBuilder plantBuilder)
        {
            _plantBuilder = plantBuilder;
        }

        public void GetPlant()
        {
            _plantBuilder.ShowPlant();
        }

        public void CreatePlant()
        {
            _plantBuilder.CreatePlant();
        }
    }

    abstract class PlantBuilder
    {
        protected Plant _plant;

        public PlantBuilder()
        {
            _plant = new Plant();
        }

        public virtual void ShowPlant()
        {
            Console.WriteLine("Plant's roots: {0}", _plant.roots);
            Console.WriteLine("Plant's stem: {0}", _plant.stem);
            Console.WriteLine("Plant's flower: {0}", _plant.flower);
            Console.WriteLine("Plant's fruit: {0}", _plant.fruit);
        }

        protected virtual void SetRoots()
        {
            _plant.roots = "Weird Roots";
        }
        protected virtual void SetStem()
        {
            _plant.stem = "No Stem";
        }
        protected abstract void SetFlower();
        protected abstract void SetFruit();

        public virtual void CreatePlant()
        {
            SetRoots();
            SetStem();
            SetFlower();
            SetFruit();
        }


    }

    class PineappleBuilder : PlantBuilder
    {

        protected override void SetFlower()
        {
            _plant.flower = "Ugly flower";
        }

        protected override void SetFruit()
        {
            _plant.fruit = "Disgusting Fruit";
        }

        public override void ShowPlant()
        {
            Console.WriteLine("Plant's fruit: {0}", _plant.fruit);
            Console.WriteLine("Plant's roots: {0}", _plant.roots);
            Console.WriteLine("Plant's flower: {0}", _plant.flower);
            Console.WriteLine("Plant's stem: {0}", _plant.stem);
        }
    }

    class WatermelonBuilder : PlantBuilder
    {

        protected override void SetFlower()
        {
            _plant.flower = "Awesome flower";
        }

        protected override void SetFruit()
        {
            _plant.fruit = "Awesome Fruit";
        }

    }

}
