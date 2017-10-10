using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DB.Commands.Update;
using TaskManager.DB.Repository.MCSDB_Local.WeekMstF;
using TaskManager.Model.Enums;
using TaskManager.Model.POCO;

namespace TaskManager.Services.MCS.Weeks
{
    public class WeekService : IWeekService
    {
        private Dictionary<string, Daytype> holidays;
        private Dictionary<string, Daytype> workingDays;

        private readonly IWeekMstRepository _weekMstRepository;

        public WeekService(IWeekMstRepository weekMstRepository)
        {
            _weekMstRepository = weekMstRepository;
        }

        public void UpdateWorkingDays(int year)
        {
            HolidaysConsumer consumer = new HolidaysConsumer();
            var calends = consumer.GetHolidays();

            holidays = calends.Where(p => p.Year == year && p.WorkingDayType == Daytype.Holiday).ToDictionary(
                p => p.ToDateTime().ToString("yyyyMMdd"), p => p.WorkingDayType);

            //excpetions in workingDays
            workingDays = calends.Where(p => p.Year == year && p.WorkingDayType == Daytype.WorkingDay).ToDictionary(
                p => p.ToDateTime().ToString("yyyyMMdd"), p => p.WorkingDayType);

            ProccedUpdate(year);
        }
        private void ProccedUpdate(int year)
        {
            List<WeekMst> weeksList = _weekMstRepository.GetByYear(year.ToString()).ToList();

            int workingDayCounter = 1;
            string lastMonth = null;

            foreach (var v in weeksList)
            {

                DateTime date = DateTime.ParseExact(v.BASE_YMD, "yyyyMMdd", CultureInfo.InvariantCulture);

                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday &&
                    !holidays.ContainsKey(v.BASE_YMD))
                {
                    if (lastMonth == null)
                    {
                        lastMonth = v.BASE_YM;
                    }
                    else if (lastMonth != v.BASE_YM)
                    {
                        workingDayCounter = 1;
                        lastMonth = v.BASE_YM;
                    }

                    v.BASE_WD = workingDayCounter;
                    _weekMstRepository.Update(new UpdateWorkingDayCommand(), v.Id, v.BASE_WD);
                    workingDayCounter++;
                }
                else if ((date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) &&
                         workingDays.ContainsKey(v.BASE_YMD))
                {
                    if (lastMonth == null)
                    {
                        lastMonth = v.BASE_YM;
                    }
                    else if (lastMonth != v.BASE_YM)
                    {
                        workingDayCounter = 1;
                        lastMonth = v.BASE_YM;
                    }

                    v.BASE_WD = workingDayCounter;
                    _weekMstRepository.Update(new UpdateWorkingDayCommand(), v.Id, v.BASE_WD);
                    workingDayCounter++;
                }
                else
                {
                    v.BASE_WD = -1;
                    _weekMstRepository.Update(new UpdateWorkingDayCommand(), v.Id, v.BASE_WD);
                }


            }

        }

    }
}
