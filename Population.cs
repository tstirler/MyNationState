using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            deadCount = 0;
            populationIncrease = populationList.Count / 34;
        }

        public void AddPerson()
        {
            populationList.Add(new People());
            if (populationList[populationList.Count - 1].Gender.Equals('m'))
            {
                _malePopulation++;
            } else _femalePopulation++;
        }

        //public void populationCount()
        //{
        //    _malePopulation = 0;
        //    _femalePopulation = 0;
        //    foreach (People person in populationList)
        //    {
        //        if (person.Gender.Equals('m'))
        //        {
        //            _malePopulation++;
        //        } else if(person.Gender.Equals('t'))
        //        {
        //            //count Transperson.
        //        }
        //        else _femalePopulation++;
        //    }
        //    deadCount = listOfTheDead.Count;
        //}

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

        public void update()
        {
            populationIncrease = populationList.Count / 34;

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


            for (int i = 0; i < populationIncrease; i++)
            {
                AddPerson();
            }

            //populationCount();
        }

        public void draw()
        {

        }
    }
}
