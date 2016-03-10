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
        private Dictionary<int,People> populationList;
        private int personNumber;
        private Dictionary<int, People> listOfTheDead;
        public int TotalPopulation { get { return populationList.Count; } }
        private static int _malePopulation;
        public static void IncrementMalePopulation()
        {
            _malePopulation++;
        }
        public static void DecrementMalePopulation()
        {
            _malePopulation--;
        }
        private static int _femalePopulation;
        public static void IncrementFemalePopulation()
        {
            _femalePopulation++;
        }
        public static void DecrementFemalePopulation()
        {
            _femalePopulation--;
        }
        public int MalePopulation { get { return _malePopulation; } }
        public int FemalePopulation {  get { return _femalePopulation; } }
        private int deadCount;
        public int DeadCount { get { return deadCount; } }
        private int oldestPerson;
        public int OldestPerson { get { return oldestPerson; } }
        private List<int> personBirthCheckList;
        private List<int> personDeathCheckList;

        public Population(int initialPopulation, singleDate dateToday)
        {
            personNumber = 0;
            populationList = new Dictionary<int, People>();
            listOfTheDead = new Dictionary<int, People>();
            for(int i = 0; i < initialPopulation; i++)
            {
                AddPerson(dateToday);
            }
            deadCount = 0;
        }

        public void PrintPerson(bool drawPersonUpdate, int personNumber)
        {
            if(populationList.ContainsKey(personNumber))
            {
                populationList[personNumber].draw();
            } else if(listOfTheDead.ContainsKey(personNumber))
            {
                listOfTheDead[personNumber].draw();
            }
        }

        public void AddPerson(singleDate dateToday)
        {
            personNumber++;
            populationList.Add(personNumber, new People(dateToday, personNumber));
        }

        public void countTheDead(int whoToKill)
        {
            listOfTheDead.Add(whoToKill, populationList[whoToKill]);
            if(populationList[whoToKill].Gender == 'f')
            {
                DecrementFemalePopulation();
            }
            else
            {
                DecrementMalePopulation();
            }
            populationList.Remove(whoToKill);
            deadCount++;
        }

        public void update(singleDate dateToday, bool drawPersonUpdate)
        {
            oldestPerson = 0;
            personBirthCheckList = new List<int>();
            personDeathCheckList = new List<int>();
            foreach (var person in populationList)
            {
                person.Value.update(drawPersonUpdate);
                if (person.Value.Age > oldestPerson)
                {
                    oldestPerson = person.Value.Age;
                }
                if(person.Value.IsPregnant && person.Value.PregnantCounter == 9 *30)
                {
                    personBirthCheckList.Add(person.Key);
                }

                if(!person.Value.IsAlive)
                {
                    personDeathCheckList.Add(person.Key);
                }
            }

            for (int i = 0; i < personBirthCheckList.Count; i++)
            {
                populationList[personBirthCheckList[i]].GiveBirth();
                AddPerson(dateToday);
            }

            for(int i = personDeathCheckList.Count - 1; i > 0; i--)
            {
                countTheDead(personDeathCheckList[i]);
            }

            try
            {
                maleFemaleRatio = (double)_malePopulation / _femalePopulation;
            } catch(DivideByZeroException)
            {
                maleFemaleRatio = 0;
            }
        }
    }
}
