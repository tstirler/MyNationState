﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataTypes;

namespace MyNationState
{
    class Nation
    {
        private int initalPopulation = 50;
        private string nationName;
        private Population nationPopulation;
        private GameDate nationDate;
        private singleDate DateToday;
        private int _populationCount;
        public int PopulationCount { get { return _populationCount; } }

        public Nation(string NationName)
        {
            nationDate = new GameDate();
            DateToday = new singleDate(nationDate.DayNumber, nationDate.MonthNumber, nationDate.Year);
            nationName = NationName;
            nationPopulation = new Population(initalPopulation, DateToday);
            _populationCount = nationPopulation.TotalPopulation;
        }

        private void populationChange()
        {
        }

        public void update(bool drawPersonUpdate)
        {
            nationDate.NextDay();
            DateToday = new singleDate(nationDate.DayNumber, nationDate.MonthNumber, nationDate.Year);
            nationPopulation.update(DateToday, drawPersonUpdate);
        }

        public void printPerson(bool drawPersonUpdate, int personNumber)
        {
            nationPopulation.PrintPerson(drawPersonUpdate, personNumber);
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Date: " + nationDate.Day + ", " + nationDate.DayNumber + ". " + nationDate.Month + " " + nationDate.Year + "              ");
            Console.WriteLine(this.nationName);
            Console.WriteLine("Population: " + nationPopulation.TotalPopulation + "                      ");
            Console.WriteLine("Male population: " + nationPopulation.MalePopulation + "                  ");
            Console.WriteLine("Female population: " + nationPopulation.FemalePopulation + "              ");
            Console.WriteLine("Male to Female ratio: {0}", nationPopulation.MaleFemaleRatio + "          ");
            Console.WriteLine("");
            Console.WriteLine("Oldest person alive: " + nationPopulation.OldestPerson / 360 + "          ");
            Console.WriteLine("DeadCount: " + nationPopulation.DeadCount + "         ");
        }
    }
}
