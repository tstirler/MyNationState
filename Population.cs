using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Population
    {
        private int maleFemaleRatio;
        private List<People> populationList;
        public int TotalPopulation { get { return populationList.Count; } }
        //public int MalePopulation { get { } }
        //public int FemalePopulation {  get { } }

        public Population(int initialPopulation)
        {
            populationList = new List<People>();
            for(int i = 0; i < initialPopulation; i++)
            {
                AddPerson();
            }
        }

        public void AddPerson()
        {
            populationList.Add(new People());
        }

        public void update()
        {
            foreach (People person in populationList)
            {
                person.update();
            }
        }

        public void draw()
        {

        }
    }
}
