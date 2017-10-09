using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager.DB.Repository.MCSDB_Local.CurrencyF;
using TaskManager.DB.Repository.MCSDB_Local.WeekMstF;
using TaskManager.Model.DTO;
using TaskManager.Model.POCO;

namespace TaskManager.Services.MCS
{
    public class CurrencyService : ICurrencyService
    {
        private static readonly string _url = "http://www.cbr.ru/scripts/XML_daily.asp";

        private static readonly string[] Codes = new string[6]
        {
            "BYN",
            "RUB",
            "KZT",
            "EUR",
            "UAH",
            "USD"
        };

        private DateRange dateRange;
        private readonly DateTime _defaultLeftInterval = DateTime.Now.AddDays(-7);
        private readonly DateTime _defaultRightInterval = DateTime.Now;

     
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IWeekMstRepository _weekMstRepository;


        public CurrencyService(ICurrencyRepository currencyRepository, IWeekMstRepository weekMstRepository)
        {
            _currencyRepository = currencyRepository;
            _weekMstRepository = weekMstRepository;
        }

 
   
   
        public void UpdateCurrencyInfo(DateRange customRange = null)
        {
            Console.WriteLine("UPdateCurrencyInfo Started");

            Func<DateTime, string> toYMD = (d) => d.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("ru-RU"));

            dateRange = customRange ?? new DateRange(_defaultLeftInterval, _defaultRightInterval);

            List<CurrencyInfo> resultCurrencyInformation = new List<CurrencyInfo>();

            for (DateTime i = dateRange.LeftInterval; i <= dateRange.RightInterval; i = i.AddDays(1))
            {
                string current_YMD = toYMD(i);

                var existsCurrency = _currencyRepository.GetByYMD(current_YMD);

                if ((existsCurrency != null && existsCurrency.Any()) ||
                    i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                string week = _weekMstRepository.GetByYMD(current_YMD).First().BASE_YW;
                string rawResult =
                new WebClient().DownloadString(
                        string.Format($"{_url}?date_req={i.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("ru-RU"))}")
                        );

                var result = XElement.Parse(rawResult).Elements("Valute").Select(p => new
                {
                    CharCode = p.Element("CharCode").Value,
                    Nominal = int.Parse(p.Element("Nominal").Value),
                    Value =
                        Decimal.Parse(p.Element("Value").Value, NumberStyles.Currency,
                           CultureInfo.GetCultureInfo("ru-RU"))
                }).Where(p => Codes.Contains(p.CharCode)).ToList();

                var sourceCurrency = result.First(p => p.CharCode == "USD");
                result.RemoveAll(p => p.CharCode == "USD");

                CurrencyInfo currencyInfo = new CurrencyInfo()
                {
                    CWeek = week,
                    Ratio = sourceCurrency.Value,
                    Destination = "RUB",
                    Source = "USD",
                    Date_YMD = current_YMD
                };
                List<CurrencyInfo> list2 = result.Select(p => new CurrencyInfo()
                {
                    Source = "USD",
                    Destination = p.CharCode,
                    CWeek = week,
                    Ratio = Decimal.Round(sourceCurrency.Value / p.Value * p.Nominal, 4),
                    Date_YMD = current_YMD
                }).ToList();
                list2.Add(currencyInfo);

                List<CurrencyInfo> list3 =
                    list2.Select(p => new CurrencyInfo()
                    {
                        Source = p.Destination,
                        Destination = p.Source,
                        CWeek = p.CWeek,
                        Ratio = new Decimal(1) / p.Ratio,
                        Date_YMD = p.Date_YMD
                    }).ToList();

                CurrencyInfo[] butchResult = list2.Union(list3).ToArray();

                resultCurrencyInformation.AddRange(butchResult);

            }

            foreach (var v in resultCurrencyInformation)
            {
                _currencyRepository.Insert(v);
            }

        }
    }
}
