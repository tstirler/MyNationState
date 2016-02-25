﻿using System;
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
        private List<People> listOfTheDead;
        public int TotalPopulation { get { return populationList.Count; } }
        private int _malePopulation;
        private int _femalePopulation;
        public int MalePopulation { get { return _malePopulation; } }
        public int FemalePopulation {  get { return _femalePopulation; } }
        private int deadCount;
        public int DeadCount { get { return deadCount; } }
        private People OldestPerson;
        private List<int> personBirthCheckList;
        private List<int> personDeathCheckList;

        public Population(int initialPopulation, singleDate dateToday)
        {
            personNumber = 0;
            populationList = new Dictionary<int, People>();
            listOfTheDead = new List<People>();
            for(int i = 0; i < initialPopulation; i++)
            {
                AddPerson(dateToday);
            }
            deadCount = 0;
        }

        public void AddPerson(singleDate dateToday)
        {
            personNumber++;
            populationList.Add(personNumber, new People(dateToday, personNumber));
            if (populationList[personNumber].Gender.Equals('m'))
            {
                _malePopulation++;
            } else _femalePopulation++;
        }

        public void countTheDead(int whoToKill)
        {
            listOfTheDead.Add(populationList[whoToKill]);
            populationList.Remove(whoToKill);
            deadCount++;
        }

        public void update(singleDate dateToday, bool drawPersonUpdate)
        {
            personBirthCheckList = new List<int>();
            personDeathCheckList = new List<int>();
            foreach (var person in populationList)
            {
                person.Value.update(drawPersonUpdate);
                if(person.Value.IsPregnant && person.Value.PregnantCounter == 9 *30)
                {
                    personBirthCheckList.Add(person.Key);
                }

                if(!person.Value.IsAlive)
                {
                    personDeathCheckList.Add(person.Key);
                }
            }

            for(int i = personBirthCheckList.Count -1; i > 0; i--)
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
