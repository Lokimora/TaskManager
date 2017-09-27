using System.Collections.Generic;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.MCSDB_Local.WeekMstF
{
    public interface IWeekMstRepository
    {
        IEnumerable<WeekMst> GetByYMD(string ymd);
    }
}
