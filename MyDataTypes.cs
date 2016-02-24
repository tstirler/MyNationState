using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataTypes
{
    class GameDate
    {
        private enum monthName : int
        {
            January = 0,
            February = 1,
            March = 2,
            April = 3,
            May = 4,
            June = 5,
            July = 6,
            August = 7,
            September = 8,
            October = 9,
            November = 10,
            December = 11
        }
        private enum dayName : int
        {
            Monday = 0,
            Tuesday = 1,
            Wednsday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6
        }

        private int year;
        private int month;
        private int dayOfTheMonth;
        private int day;
        private int dayOfTheWeek;

        public GameDate()
        {
            dayOfTheWeek = 0;
            dayOfTheMonth = 0;
            day = 0;
            month = 0;
            year = 0;
        }

        public int Year
        {
            get
            {
                return year;
            }
        }
        public string Month
        {
            get
            {
                return Convert.ToString((monthName)month);
            }
        }
        public int MonthNumber
        {
            get
            {
                return month;
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
                return day;
            }
        }

        public void NextDay()
        {
            //Weeks
            if(dayOfTheWeek == 6)
            {
                dayOfTheWeek = 0;
                day++;
            } else
            {
                day++;
                dayOfTheWeek++;
            }

            //Months
            if(dayOfTheMonth==30)
            {
                dayOfTheMonth = 0;
                month++;
            } else
            {
                dayOfTheMonth++;
            }

            //Years
            if(month == 12 && dayOfTheMonth == 30)
            {
                month = 0;
                day = 0;
                year++;
            }
        }
    }
}
