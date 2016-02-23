using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class People
    {
        private char gender;
        private int age;
        private bool _isAlive;

        public People()
        {
            if (Program.rnd.Next(100) > 53)
            {
                gender = 'f';
            }
            else gender = 'm';
            age = 0;
            _isAlive = true;
        }

        public void update()
        {
            age++;
        }

        public void draw()
        {

        }
    }
}
