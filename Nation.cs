using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Nation
    {
        private string nationName;
        private Population nationPopulation;

        public Nation()
        {
            nationName = "TestNation";
            nationPopulation = new Population();
        }

        private void populationChange()
        {
        }

        public void update()
        {
        }

        public void draw()
        {
            Console.WriteLine("Population: " + Population);
            Console.WriteLine("Male population: " + nationPopulationMale);
            Console.WriteLine("Female population: " + nationPopulationFemale);
        }
    }
}
