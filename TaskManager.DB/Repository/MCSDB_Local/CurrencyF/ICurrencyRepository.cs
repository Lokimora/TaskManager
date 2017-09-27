using System.Collections.Generic;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.MCSDB_Local.CurrencyF
{
    public interface ICurrencyRepository
    {
        void Update(CurrencyInfo currency);

        IEnumerable<CurrencyInfo> GetByWeek(string week);

        IEnumerable<CurrencyInfo> GetByYMD(string ymd);

        void Insert(CurrencyInfo currency);
    }
}
