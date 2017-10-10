using TaskManager.Model.DTO;

namespace TaskManager.Services.MCS.Currencies
{
    public interface ICurrencyService
    {
        void UpdateCurrencyInfo(DateRange customRange = null);
    }
}
