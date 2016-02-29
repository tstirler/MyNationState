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
            rnd = new Random();
            string playerArgs;

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

                playerArgs = Console.ReadLine();
                if (!playerArgs.Equals(""))
                {
                    Convert.ToInt32(playerArgs);
                    flags.DrawPersonUpdate = true;
                    myNation.update(flags.DrawPersonUpdate);
                }
                else
                {
                    myNation.update(flags.DrawPersonUpdate);
                }
                #endregion
            }
            
            Console.Read();
        }
    }
}
