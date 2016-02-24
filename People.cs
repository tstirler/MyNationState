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

        private int lifeSpan;

        public People()
        {
            lifeSpan = Program.rnd.Next(3650);
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
            if(age >= lifeSpan)
            {
                _isAlive = false;
            }
        }

        public void draw()
        {

        }
    }
}
