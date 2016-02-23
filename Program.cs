using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            //generate nation
            Nation myNation = new Nation();

            //run
            while (myNation.Population > 0)
            {
                myNation.update();
                myNation.draw();
                Console.ReadLine();
            }
            Console.Read();
        }
    }
}
