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
        struct GameFlags
        {
            public int TimeCounterDays;
            public int TimeCounterYears;
            public int MonthLength;
            public int NumberOfMonths;
            public int YearsToCalculate;
            public bool DrawPersonUpdate;
        }

        static GameFlags flags;
        public static Random rnd;
<<<<<<< HEAD
        public static int timeCounterDays;
        public static int timeCounterYears;
        public static int monthLength;
        public static int numberOfMonths;
        

        static void Main(string[] args)
        {
            string playerArgs;
            timeCounterDays = 0;
            timeCounterYears = 0;
            monthLength = 30;
            int yearsToCalculate = 20;
            bool drawPersonUpdate = false;
            
=======

        static void Main(string[] args)
        {
            #region Set Flags
            flags = new GameFlags();
            flags.TimeCounterDays = 0;
            flags.TimeCounterYears = 0;
            flags.MonthLength = 30;
            flags.YearsToCalculate = 50;
            flags.DrawPersonUpdate = false;
            #endregion

            string nationName;
>>>>>>> origin/master
            rnd = new Random();
            //generate nation
            Console.WriteLine("Please input nation name: ");
            nationName = Console.ReadLine();
            Nation myNation = new Nation(nationName);

            #region Calculate Generations
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Calculating Generations.");
            Console.Write("|");
            for(int i = 0; i <= flags.YearsToCalculate; i++)
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
            for (int i = 0; i < 360 * flags.YearsToCalculate; i++)
            {
                if (i % 360 == 0) Console.Write("X");
                myNation.update(flags.DrawPersonUpdate);
            }
            #endregion

            Console.Clear();

            #region Main Gameloop
            //flags.DrawPersonUpdate = true;
            while (myNation.PopulationCount > 0)
            {
                myNation.draw();
<<<<<<< HEAD
                playerArgs = Console.ReadLine();
                if (!playerArgs.Equals(""))
                {
                    Convert.ToInt32(playerArgs);
=======
                Console.ReadLine();
                myNation.update(flags.DrawPersonUpdate);
            }
            #endregion
>>>>>>> origin/master

                } else (playerArgs.Equals(""))
                {
                    myNation.update(drawPersonUpdate);
                }
            }
            
            Console.Read();
        }
    }
}
