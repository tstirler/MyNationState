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
        private List<People> listOfTheDead;
        public int TotalPopulation { get { return populationList.Count; } }
        private int _malePopulation;
        private int _femalePopulation;
        public int MalePopulation { get { return _malePopulation; } }
        public int FemalePopulation {  get { return _femalePopulation; } }
        private int populationIncrease;
        private int deadCount;
        public int DeadCount { get { return deadCount; } }

        public Population(int initialPopulation)
        {
            populationList = new List<People>();
            listOfTheDead = new List<People>();
            for(int i = 0; i < initialPopulation; i++)
            {
                AddPerson();
            }
            populationIncrease = populationList.Count / 100;
            deadCount = 0;
        }

        public void AddPerson()
        {
            populationList.Add(new People());
        }

        public void populationCount()
        {
            _malePopulation = 0;
            _femalePopulation = 0;
            foreach (People person in populationList)
            {
                if (person.Gender.Equals('m'))
                {
                    _malePopulation++;
                } else if(person.Gender.Equals('t'))
                {
                    //count Transperson.
                }
                else _femalePopulation++;
            }
            deadCount = listOfTheDead.Count;
        }

        public void update()
        {
            populationIncrease = populationList.Count / 40;
            int populationAmount = populationList.Count;
            People personToCheck;
            foreach (People person in populationList)
            {
                person.update();
            }

            for(int i = populationAmount -1; i >= 0; i--)
            {
                personToCheck = populationList[i];
                if (!populationList[i].IsAlive)
                {
                    listOfTheDead.Add(personToCheck);
                    populationList.Remove(populationList[i]);
                }
            }

            for (int i = 0; i < populationIncrease; i++)
            {
                populationList.Add(new People());
            }

            populationCount();
        }

        public void draw()
        {

        }
    }
}
