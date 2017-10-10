using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using TaskManager.DB.Context;
using TaskManager.DB.Repository.MCSDB_Local.CurrencyF;
using TaskManager.DB.Repository.MCSDB_Local.WeekMstF;
using TaskManager.Services.MCS;
using TaskManager.Services.MCS.Currencies;
using TaskManager.Services.MCS.Weeks;

namespace TaskManager.Infrastructure
{
    public static class ContainerFactory
    {
        private static Container _container;
    
        public static void RegisterContainer()
        {
            string mcsdbLocalConnection = ConfigurationManager.ConnectionStrings["MCSDB_LOCAL_DB"].ConnectionString;
            string bonusConnection = ConfigurationManager.ConnectionStrings["BONUS_DB"].ConnectionString;

            _container = new Container();

            
            _container.Register<McsdbLocalConnection>(() => new McsdbLocalConnection(mcsdbLocalConnection));
            _container.Register<BonusConnection>(() => new BonusConnection(bonusConnection));
            _container.Register<ICurrencyRepository, CurrencyRepository>(Lifestyle.Transient);
            _container.Register<IWeekMstRepository, WeekMstRepository>(Lifestyle.Transient);
            _container.Register<CurrencyService>(() => new CurrencyService(
                _container.GetInstance<ICurrencyRepository>(),
                _container.GetInstance<IWeekMstRepository>()));
            _container.Register<IWeekService, WeekService>();

            _container.Verify();

        }

        public static Container GetContainer()
        {
            if(_container == null)
                RegisterContainer();

            return _container;

        }
    }
}
