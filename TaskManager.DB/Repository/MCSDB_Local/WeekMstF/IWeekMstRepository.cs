using System.Collections.Generic;
using TaskManager.DB.Commands;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.MCSDB_Local.WeekMstF
{
    public interface IWeekMstRepository
    {
        IEnumerable<WeekMst> GetByYMD(string ymd);
        IEnumerable<WeekMst> GetByYear(string year);
        void Update(ICommand command, int id, int base_wd);

    }


}
