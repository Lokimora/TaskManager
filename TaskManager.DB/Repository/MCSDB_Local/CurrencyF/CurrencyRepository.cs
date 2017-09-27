using System;
using System.Collections.Generic;
using Dapper;
using TaskManager.DB.Context;
using TaskManager.Model.POCO;

namespace TaskManager.DB.Repository.MCSDB_Local.CurrencyF
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly McsdbLocalConnection _mcsdbLocal;

        public CurrencyRepository(McsdbLocalConnection mcsdbLocal)
        {
            _mcsdbLocal = mcsdbLocal;
        }

        public void Update(CurrencyInfo currency)
        {
            throw new NotImplementedException();
            //_mcsdbLocal._db.Execute("UPDATE CurrencyRates")
        }

        public IEnumerable<CurrencyInfo> GetByWeek(string week)
        {
            return _mcsdbLocal.DB.Query<CurrencyInfo>(
                "SELECT Id, Source, Destination, CWeek, Ratio, DATE_YMD FROM Ru.CurrencyRates WHERE CWeek = @week",
                new { week });
        }

        public IEnumerable<CurrencyInfo> GetByYMD(string ymd)
        {
            return _mcsdbLocal.DB.Query<CurrencyInfo>(
                "SELECT Id, Source, Destination, CWeek, Ratio, DATE_YMD FROM Ru.CurrencyRates WHERE DATE_YMd = @ymd",
                new { ymd });
        }

        public void Insert(CurrencyInfo currency)
        {
            _mcsdbLocal.DB.Query("INSERT INTO Ru.CurrencyRates (Source, Destination, CWeek, Ratio, DATE_YMD)" +
                                 "VALUES(@Source, @Destination, @CWeek, @Ratio, @DATE_YMD)",
                new
                {
                    Source = currency.Source,
                    Destination = currency.Destination,
                    CWeek = currency.CWeek,
                    Ratio = currency.Ratio,
                    DATE_YMD = currency.Date_YMD
                });
        }
    }
}
