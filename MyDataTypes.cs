using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataTypes
{
    enum monthName : int
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    enum dayName : int
    {
        Monday = 1,
        Tuesday,
        Wednsday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    class GameDate
    {
        private singleDate currentDate;
        private int dayOfTheWeek;

        public GameDate()
        {
            currentDate = new singleDate(1, 1, 0);
            dayOfTheWeek = 1;
        }

        public int Year
        {
            get { return currentDate.Year; }
        }
        public string Month
        {
            get
            {
                return Convert.ToString((monthName)currentDate.Month);
            }
        }
        public int MonthNumber
        {
            get
            {
                return currentDate.Month;
            }
        }
        public string Day
        {
            get
            {
                return Convert.ToString((dayName)dayOfTheWeek) ;
            }
        }
        public int DayNumber
        {
            get
            {
                return currentDate.Day;
            }
        }

        public void NextDay()
        {
            //Years
            if (currentDate.Month == 12 && currentDate.Day == 30)
            {
                currentDate.Month = 1;
                currentDate.Day = 1;
                currentDate.Year++;
            }

            //Months
            if (currentDate.Day == 30)
            {
                currentDate.Day = 1;
                currentDate.Month++;
            }
            else
            {
                currentDate.Day++;
            }

            //Weeks
            if (dayOfTheWeek == 7)
            {
                dayOfTheWeek = 1;
            } else
            {
                dayOfTheWeek++;
            } 
        }
    }

    struct singleDate
    {
        private int year;
        private int month;
        private int day;
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public int Month
        {
            get { return month; }
            set { month = value; }
        }
        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public singleDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
    }
}
