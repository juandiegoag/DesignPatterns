using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Adapter
    {
        public Adapter()
        {
            ISkillsTransferer Isk = new RacoonConverter();
            Dog dog = new Dog(Isk);
            dog.Steal();
        }
    }

    class Dog
    {
        private ISkillsTransferer _newSkills;
        public Dog(ISkillsTransferer newSkills)
        {
            _newSkills = newSkills;
        }

        public void Steal()
        {
            _newSkills.Steal();
        }
    }

    public interface ISkillsTransferer
    {
        void Steal();
    }

    class RacoonConverter : Racoon, ISkillsTransferer
    {
        public void Steal()
        {
            RacoonSteal();
        }
    }

    class Racoon
    {
        public void RacoonSteal()
        {
            Console.WriteLine("[RACOON] Stealing food yo'");
        }
    }

}
