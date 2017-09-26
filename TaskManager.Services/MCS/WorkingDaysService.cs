//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskManager.Services.MCS
//{
//    public class WorkingDaysService
//    {
//        private Dictionary<string, Daytype> holidays;
//        private Dictionary<string, Daytype> workingDays;


//        /// <summary>
//        /// updates working day in week_mst
//        /// </summary>
//        /// <param name="calends"></param>
//        /// <param name="year">year that will be updated</param>
//        public void UpdateWorkingDays(int year)
//        {
//            HolidaysConsumer consumer = new HolidaysConsumer();
//            var calends = consumer.GetHolidays();

//            holidays = calends.Where(p => p.Year == year && p.WorkingDayType == Daytype.Holiday).ToDictionary(
//               p => p.ToDateTime().ToString("yyyyMMdd"), p => p.WorkingDayType);

//            //excpetions in workingDays
//            workingDays = calends.Where(p => p.Year == year && p.WorkingDayType == Daytype.WorkingDay).ToDictionary(
//                p => p.ToDateTime().ToString("yyyyMMdd"), p => p.WorkingDayType);

//            ProccedUpdate(year);
//        }

//        private void ProccedUpdate(int year)
//        {
//            List<WeekMst> weeksList = new List<WeekMst>();
//            using (var db = new McsdbLocal())
//            {
//                weeksList = db.WeekMst.Where(p => p.BASE_YY == year.ToString()).ToList();
//            }

//            int workingDayCounter = 1;
//            string lastMonth = null;
//            obje dbConnection = null;// new McsdbLocal();
//            foreach (var v in weeksList)
//            {

//                DateTime date = DateTime.ParseExact(v.BASE_YMD, "yyyyMMdd", CultureInfo.InvariantCulture);

//                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday &&
//                    !holidays.ContainsKey(v.BASE_YMD))
//                {
//                    if (lastMonth == null)
//                    {
//                        lastMonth = v.BASE_YM;
//                    }
//                    else if (lastMonth != v.BASE_YM)
//                    {
//                        workingDayCounter = 1;
//                        lastMonth = v.BASE_YM;
//                    }

//                    v.BASE_WD = workingDayCounter;
//                    dbConnection.Update(v);
//                    workingDayCounter++;
//                }
//                else if ((date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) &&
//                         workingDays.ContainsKey(v.BASE_YMD))
//                {
//                    if (lastMonth == null)
//                    {
//                        lastMonth = v.BASE_YM;
//                    }
//                    else if (lastMonth != v.BASE_YM)
//                    {
//                        workingDayCounter = 1;
//                        lastMonth = v.BASE_YM;
//                    }

//                    v.BASE_WD = workingDayCounter;
//                    dbConnection.Update(v);
//                    workingDayCounter++;
//                }
//                else
//                {
//                    v.BASE_WD = -1;
//                    dbConnection.Update(v);
//                }


//            }

//            dbConnection.Close();
//        }

//    }
//}
