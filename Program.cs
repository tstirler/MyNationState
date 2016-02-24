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

        static void Main(string[] args)
        {
            timeCounterDays = 0;
            timeCounterYears = 0;
            monthLength = 30;
            rnd = new Random();
            //generate nation
            Nation myNation = new Nation();

            //run
            while (myNation.PopulationCount > 0)
            {
                myNation.update();
                myNation.draw();
                Console.ReadLine();
            }
            Console.Read();
        }
    }
}
