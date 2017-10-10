using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model.Enums;

namespace TaskManager.Model.DTO
{
    public class CalendObject
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public Daytype WorkingDayType { get; set; }

        private CalendObject() { }

        public CalendObject(int year, int month, int day, Daytype workingDayType)
        {
            Year = year;
            Month = month;
            Day = day;
            WorkingDayType = workingDayType;
        }


        public DateTime ToDateTime()
        {
            return new DateTime(Year, Month, Day);
        }
    }
}
