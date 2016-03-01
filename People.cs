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

        private string getFemaleFirstName()
        {
            string firstName;
            firstName = Enum.GetName(typeof(FemaleNames), Program.rnd.Next(Enum.GetNames(typeof(FemaleNames)).Length));
            return firstName;
        }

        private string getMaleFirstName()
        {
            string firstName;
            firstName = Enum.GetName(typeof(MaleNames), Program.rnd.Next(Enum.GetNames(typeof(MaleNames)).Length));
            return firstName;
        }

        public People(singleDate birthDay, int personNumber)
        {
            lifeSpan = Program.rnd.Next(30 * 360, 100 * 360);
            if (Program.rnd.Next(100) > 53)
            {
                this.gender = 'f';
                Population.IncrementFemalePopulation();
                this.PersonName = new personName(getFemaleFirstName(), "Doe");
            }
            else
            {
                this.gender = 'm';
                Population.IncrementMalePopulation();
                this.PersonName = new personName(getMaleFirstName(), "Doe");
            }
            this.age = 0;
            this._isAlive = true;
            this.birthDay = birthDay;
            this.isPregnant = false;
            this.personNumber = personNumber;
        }

        public void update(bool willDraw)
        {
            this.age++;
            
            if(this.age >= lifeSpan) this._isAlive = false;
            
            if(this.age > (360 * 16) && this.age < (360 * 45) && this.gender.Equals('f') && Program.rnd.Next(100) < chanceToGetPregnant && !this.isPregnant)
            {
                this.BecomePregnant();
            }

            if (this.isPregnant) this.pregnantCounter++;
            if(willDraw) this.draw();
        }

        public void BecomePregnant()
        {
            this.isPregnant = true;
            this.pregnantCounter = 0;
        }
        public void GiveBirth()
        {
            this.isPregnant = false;
        }

        public void draw()
        {
            Console.SetCursorPosition(0, 15);;
            Console.WriteLine("Person Number: " + this.personNumber + "\tFirst name: " + PersonName.FirstName + " Last name: " + PersonName.LastName + "             ");
            Console.WriteLine("Age: " + this.age/360 + "y " + (this.age%360) /30 + "m " + (this.age % 360) % 12 + "d, Gender: " + this.Gender);
            Console.WriteLine("Is Alive: " + this.IsAlive + "             ");
            Console.WriteLine("Is Pregnant: " + this.IsPregnant + "             ");
        }
    }
}
