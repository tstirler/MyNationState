using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataTypes;

namespace MyNationState
{
    class Population
    {
        private double maleFemaleRatio;
        public double MaleFemaleRatio { get { return maleFemaleRatio; } }
        private List<People> populationList;
        private List<People> listOfTheDead;
        public int TotalPopulation { get { return populationList.Count; } }
        private int _malePopulation;
        private int _femalePopulation;
        public int MalePopulation { get { return _malePopulation; } }
        public int FemalePopulation {  get { return _femalePopulation; } }
        private int deadCount;
        public int DeadCount { get { return deadCount; } }

        public Population(int initialPopulation, singleDate dateToday)
        {
            populationList = new List<People>();
            listOfTheDead = new List<People>();
            for(int i = 0; i < initialPopulation; i++)
            {
                AddPerson(dateToday);
            }
            deadCount = 0;
        }

        public void AddPerson(singleDate dateToday)
        {
            populationList.Add(new People(dateToday));
            if (populationList[populationList.Count - 1].Gender.Equals('m'))
            {
                _malePopulation++;
            } else _femalePopulation++;
        }

        public void countTheDead()
        {
            for (int i = populationList.Count - 1; i >= 0; i--)
            {
                People personToCheck;
                personToCheck = populationList[i];
                if (!populationList[i].IsAlive)
                {
                    if (personToCheck.Gender.Equals('m'))
                    {
                        _malePopulation--;
                    }
                    else _femalePopulation--;
                    listOfTheDead.Add(personToCheck);
                    populationList.Remove(populationList[i]);
                    deadCount++;
                }
            }
        }

        public void update(singleDate dateToday)
        {
            foreach (People person in populationList)
            {
                person.update();
            }

            countTheDead();
            try
            {
                maleFemaleRatio = (double)_malePopulation / _femalePopulation;
            } catch(DivideByZeroException)
            {
                maleFemaleRatio = 0;
            }
        }

        public void draw()
        {

        }
    }
}
