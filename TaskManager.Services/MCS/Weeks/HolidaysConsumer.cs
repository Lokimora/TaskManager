using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaskManager.Model.DTO;
using TaskManager.Model.Enums;

namespace TaskManager.Services.MCS.Weeks
{
    public class HolidaysConsumer
    {
        private readonly string _mainUrl;
        private List<CalendObject> _data;

        public HolidaysConsumer()
        {
            _mainUrl = "http://basicdata.ru/api/json/calend/";
            _data = new List<CalendObject>();
        }

        public List<CalendObject> GetHolidays()
        {
            if (_data.Count > 0)
            {
                return _data;
            }

            return GetData();
        }


        private List<CalendObject> GetData()
        {
            string rawResponse = null;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_mainUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (var stream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    rawResponse = sr.ReadToEnd();
                }
            }

            return TransformRawData(rawResponse);
        }

        private List<CalendObject> TransformRawData(string rawData)
        {
            var converter = new ExpandoObjectConverter();
            dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(rawData, converter);

            List<CalendObject> calends = new List<CalendObject>();

            foreach (var v in obj.data)
            {
                int year = Int32.Parse(v.Key);
                foreach (var m in v.Value)
                {
                    int month = Int32.Parse(m.Key);

                    foreach (var d in m.Value)
                    {
                        int day = Int32.Parse(d.Key);
                        foreach (var w in d.Value)
                        {
                            Daytype dayType = Enum.Parse(typeof(Daytype), w.Value.ToString(), true);
                            CalendObject calend = new CalendObject(year, month, day, dayType);
                            calends.Add(calend);
                        }
                    }
                }
            }

            return calends.ToList();
        }
    }
}
