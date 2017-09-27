using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManager.DB.Context;
using TaskManager.DB.Repository.MCSDB_Local.CurrencyF;

namespace TaskManager.tests
{
    [TestClass]
    public class UnitTest1
    {
        private const string mcsdbLocalConnectionString = "Data Source=182.198.101.62;Initial Catalog=MCSDB_Local;User ID=appladm;Password=tkatjd!23";

        [TestMethod]
        public void GetCurrencies()
        {
            
            CurrencyRepository currencyRepository = new CurrencyRepository(new McsdbLocalConnection(
                mcsdbLocalConnectionString
                ));
            var data = currencyRepository.GetByWeek("201730");

            Assert.AreNotEqual(null, data);
        }
    }
}
