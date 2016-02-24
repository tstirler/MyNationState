using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataTypes;

namespace MyNationState
{
    class Nation
    {
        private int initalPopulation = 5000;
        private string nationName;
        private Population nationPopulation;
        private GameDate nationDate;
        private int _populationCount;
        public int PopulationCount { get { return _populationCount; } }

        public Nation()
        {
            nationDate = new GameDate();
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
            nationDate.NextDay();
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Date: " + nationDate.Day + ", " + nationDate.DayNumber + ". " + nationDate.Month + " " + nationDate.Year + "              ");
            Console.WriteLine("");
            Console.WriteLine("Population: " + nationPopulation.TotalPopulation);
            Console.WriteLine("Male population: " + nationPopulation.MalePopulation);
            Console.WriteLine("Female population: " + nationPopulation.FemalePopulation);
            Console.WriteLine("Male to Female ratio: {0}", nationPopulation.MaleFemaleRatio);
            Console.WriteLine("");
            Console.WriteLine("DeadCount: " + nationPopulation.DeadCount);
            nationPopulation.draw();
        }
    }
}
