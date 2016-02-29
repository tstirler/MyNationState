using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataTypes;

namespace MyNationState
{
    class People
    {
        private char gender;
        private int age;
        private bool _isAlive;
        public bool IsAlive { get { return _isAlive; } }
        public char Gender { get { return gender; } }
        private singleDate birthDay;
        public int Age { get { return age; } }
        private bool isPregnant;
        public bool IsPregnant { get { return isPregnant; } }
        private int pregnantCounter;
        public int PregnantCounter { get { return pregnantCounter; } }
        private int personNumber;
        public int PersonNumber { get { return personNumber; } }
        private int chanceToGetPregnant = 1;
        public personName PersonName;

        private int lifeSpan;

        public People(singleDate birthDay, int personNumber)
        {
            lifeSpan = Program.rnd.Next(50 * 360, 100 * 360);
            if (Program.rnd.Next(100) > 53)
            {
                gender = 'f';
                PersonName = new personName("Jane", "Doe");
            }
            else
            {
                gender = 'm';
                PersonName = new personName("John", "Doe");
            }
            age = 0;
            _isAlive = true;
            this.birthDay = birthDay;
            this.isPregnant = false;
            this.personNumber = personNumber;
        }

        public void update(bool willDraw)
        {
            age++;
            
            if(age >= lifeSpan) _isAlive = false;
            
            if(age > (360 * 16) && age < (360 * 45) && gender.Equals('f') && Program.rnd.Next(100) < chanceToGetPregnant && !isPregnant)
            {
                BecomePregnant();
            }

            if (isPregnant) pregnantCounter++;
            if(willDraw) draw();
        }

        public void BecomePregnant()
        {
            isPregnant = true;
            pregnantCounter = 0;
        }
        public void GiveBirth()
        {
            isPregnant = false;
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Updating person:");
            Console.WriteLine("Person Number: " + this.personNumber + " First name: " + PersonName.FirstName + " Last name:" + PersonName.LastName);
            Console.WriteLine("Age: " + this.age/360 + "             ");
            Console.WriteLine("Is Alive: " + this.IsAlive + "             ");
            Console.WriteLine("Is Pregnant: " + this.IsPregnant + "             ");
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Done updating.  ");
            Console.SetCursorPosition(0, 20);
        }
    }
}
