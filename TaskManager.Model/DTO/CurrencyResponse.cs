using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model.DTO
{
    public class CurrencyResponse
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<string> Rates { get; set; }
    }
}
