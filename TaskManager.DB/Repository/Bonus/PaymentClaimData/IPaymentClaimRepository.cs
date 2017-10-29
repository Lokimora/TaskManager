using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model.DTO.Bonus;

namespace TaskManager.DB.Repository.Bonus.PaymentClaimData
{
    public interface IPaymentClaimRepository
    {
        IEnumerable<CreatePaymentClaimData> GetClaimsToCreate();

        bool CreateClaim(CreatePaymentClaimData paymentInfo, ref string errorMessage);
    }
}
