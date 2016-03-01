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
            string playerInput;
            rnd = new Random();
            string playerArgs;

            //generate nation
            Console.WriteLine("Please input nation name: ");
            nationName = Console.ReadLine();
            Nation myNation = new Nation(nationName);
            Console.WriteLine("How many years do you want to pre-simulate? Default 50.");
            Console.WriteLine("Warning, simulating many years takes a long time.");
            playerInput = Console.ReadLine();
            if (!playerInput.Equals(""))
            {
                try
                {
                    flags.YearsToCalculate = Convert.ToInt32(playerInput);
                } catch (FormatException)
                { }
            }

            int printPersonNumber;

            #region Calculate Generations
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            Console.WriteLine("Calculating Years. Y: years, D: decades, C: centuries");
            for(int i = 0; i <= flags.YearsToCalculate; i++)
            {
                if (i == 0)
                {
                    Console.Write("|");
                }
                else if (i % 10 == 0)
                {
                    Console.Write("I");
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.Write("|");
            Console.SetCursorPosition(1, 1);
            for (int i = 1; i <= 360 * flags.YearsToCalculate; i++)
            {
                if(i % 36000 == 0)
                {
                    Console.Write("C");
                }
                else if (i % 3600 == 0)
                {
                    Console.Write("D");
                }
                else if (i % 360 == 0)
                {
                    Console.Write("Y");
                }
                myNation.update(flags.DrawPersonUpdate);
            }
            #endregion

            Console.Clear();

            #region Main Gameloop
            //flags.DrawPersonUpdate = true;
            while (myNation.PopulationCount > 0)
            {
                myNation.draw();

                printPersonNumber = -1;
                Console.WriteLine("Please enter command.\r\nType the person-number to view that person, or 'next' to forward to next day.");
                playerArgs = Console.ReadLine();
                Console.Clear();
                try
                {
                    printPersonNumber = Convert.ToInt32(playerArgs);
                } catch(FormatException)
                {
                }
                if (printPersonNumber > -1)
                {
                    
                    flags.DrawPersonUpdate = true;
                    myNation.printPerson(flags.DrawPersonUpdate, printPersonNumber);
                    flags.DrawPersonUpdate = false;
                }
                else if(playerArgs.ToLower().Equals("next"))
                {
                    int numberOfDaysToProgress = 1;
                    int numberOfYearsProgressed = 0;
                    bool inputNumeric = false;
                    
                    Console.WriteLine("How many days do you wish to simulate?");
                    while (!inputNumeric)
                    {
                        playerInput = Console.ReadLine();
                        try
                        {
                            numberOfDaysToProgress = Convert.ToInt32(playerInput);
                            inputNumeric = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Not a valid input, please enter a number.");
                        }
                    }
                    for (int i = 0; i < numberOfDaysToProgress; i++)
                    {
                        if(i%360==0)
                        {
                            numberOfYearsProgressed++;
                            if (numberOfYearsProgressed % 100 == 0)
                            {
                                Console.Write("C");
                            }
                            else if (numberOfYearsProgressed % 10 == 0)
                            {
                                Console.Write("D");
                            }
                            else
                            {
                                Console.Write("Y");
                            }
                        }
                        myNation.update(flags.DrawPersonUpdate);
                    }
                    Console.Clear();
                }
                #endregion
            }
            
            Console.Read();
        }
    }
}
