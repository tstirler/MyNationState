using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataTypes;

namespace MyNationState
{
    class Program
    {
        public static Random rnd;
        public static int timeCounterDays;
        public static int timeCounterYears;
        public static int monthLength;
        public static int numberOfMonths;

        static void Main(string[] args)
        {
            timeCounterDays = 0;
            timeCounterYears = 0;
            monthLength = 30;
            int yearsToCalculate = 50;
            bool drawPersonUpdate = false;
            
            rnd = new Random();
            //generate nation
            Nation myNation = new Nation();

            Console.WriteLine("Calculating Generations.");
            Console.Write("|");
            for(int i = 0; i <= yearsToCalculate; i++)
            {
                if (i % 10 == 0)
                {
                    Console.Write("#");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.Write("|");
            Console.SetCursorPosition(1, 1);
            for (int i = 0; i < 360 * yearsToCalculate; i++)
            {
                if (i % 360 == 0) Console.Write("X");
                myNation.update(drawPersonUpdate);
            }

            Console.Clear();
            //run
            
            while (myNation.PopulationCount > 0)
            {
                myNation.draw();
                Console.ReadLine();
                myNation.update(drawPersonUpdate);
            }


            Console.Read();
        }
    }
}
