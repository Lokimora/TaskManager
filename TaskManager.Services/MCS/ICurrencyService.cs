using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model.DTO;

namespace TaskManager.Services.MCS
{
    public interface ICurrencyService
    {
        void UpdateCurrencyInfo(DateRange customRange = null);
    }
}
