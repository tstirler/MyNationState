using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNationState
{
    class Population
    {
        private int maleFemaleRatio;
        private List<People> maleList;
        private List<People> femaleList;

        public Population()
        {
            maleList = new List<People>();
            maleList = new List<People>();
        }

        public void update()
        {
            foreach (People person in maleList)
            {
                person.update();
            }

            foreach (People person in femaleList)
            {
                person.update();
            }
        }

        public void draw()
        {

        }
    }
}
