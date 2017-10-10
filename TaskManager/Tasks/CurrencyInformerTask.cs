using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimpleInjector;
using TaskManager.Model.DTO;
using TaskManager.Model.POCO;
using TaskManager.Services.MCS;
using TaskManager.Services.MCS.Currencies;
using TaskRunner;

namespace TaskManager.Tasks
{
    public class CurrencyInformerTask : ITask
    {
        private CurrencyService _currencyService;

        public CurrencyInformerTask(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }


        public void Run(object options)
        {        
            var opt = options as Options;

            if (opt == null)
                throw new ArgumentException("Invalid options type");

            var oneDayRange = new DateRange(DateTime.Now.AddDays(-1), DateTime.Now);

            _currencyService.UpdateCurrencyInfo(oneDayRange);

        }
    }
}
