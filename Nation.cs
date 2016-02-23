using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Nation
    {
        private int initalPopulation = 5000;
        private string nationName;
        private Population nationPopulation;
        private int _populationCount;
        public int PopulationCount { get { return _populationCount; } }
        public Nation()
        {
            nationName = "TestNation";
            nationPopulation = new Population(initalPopulation);
            _populationCount = nationPopulation.TotalPopulation;
        }

        private void populationChange()
        {
        }

        public void update()
        {
            nationPopulation.update();
        }

        public void draw()
        {
            Console.WriteLine("Population: " + nationPopulation.TotalPopulation);
            //Console.WriteLine("Male population: " + nationPopulation.MalePopulation);
            //Console.WriteLine("Female population: " + nationPopulation.FemalePopulation);
            nationPopulation.draw();
        }
    }
}
