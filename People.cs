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
        public bool IsAlive { get { return _isAlive; } }
        public char Gender { get { return gender; } }

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
            if (age >= 47 && gender.Equals('m'))
            {
                _isAlive = false;
            } else if (age >= 50 && gender.Equals('f'))
            {
                _isAlive = false;
            }
        }

        public void draw()
        {

        }
    }
}
