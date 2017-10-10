using System;
using System.Collections.Generic;
using Dapper;
using TaskManager.DB.Context;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.MCSDB_Local.WeekMstF
{
    public class WeekMstRepository : IWeekMstRepository
    {
        private McsdbLocalConnection _mcsdbLocal;

        public WeekMstRepository(McsdbLocalConnection mcsdbLocal)
        {
            _mcsdbLocal = mcsdbLocal;
        }

        public IEnumerable<WeekMst> GetByYMD(string ymd)
        {
            return _mcsdbLocal.DB.Query<WeekMst>("SELECT Id, BASE_YMD, BASE_YW FROM RU.Week_Mst WHERE BASE_YMD = @ymd",
                new {ymd});
        }

        public IEnumerable<WeekMst> GetByYear(string year)
        {
            return _mcsdbLocal.DB.Query<WeekMst>("SELECT Id, BASE_YMD, BASE_YW, BASE_YY FROM RU.Week_Mst WHERE BASE_YY = @year",
                new { year });
        }
    }
}
