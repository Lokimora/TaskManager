using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Model.POCO
{
    public class CurrencyInfo
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string CWeek { get; set; }
        public Decimal Ratio { get; set; }
        public string Date_YMD { get; set; }
    }
}
