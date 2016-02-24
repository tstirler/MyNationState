using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Program
    {
        public static Random rnd;

        static void Main(string[] args)
        {
            rnd = new Random();
            //generate nation
            Nation myNation = new Nation();

            //run
            while (myNation.PopulationCount > 0)
            {
                myNation.update();
                myNation.draw();
                //Console.ReadLine();
            }
            Console.Read();
        }
    }
}
