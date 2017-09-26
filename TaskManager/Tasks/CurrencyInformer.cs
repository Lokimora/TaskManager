using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager.Model.DTO;
using TaskManager.Model.POCO;
using TaskManager.Services.MCS;
using TaskRunner;

namespace TaskManager.Tasks
{
    public class CurrencyInformer : ITask
    {
        public void Run(object options)
        {
            var opt = options as Options;

            if (opt == null)
                throw new ArgumentException("Invalid options type");

            var oneDayRange = new DateRange(DateTime.Now.AddDays(-1), DateTime.Now);

            CurrencyService currencyService = new CurrencyService(oneDayRange);
            currencyService.UpdateCurrencyInfo();

        }
    }
}
