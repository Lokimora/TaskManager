using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DB.Context;
using TaskManager.Model.DTO.Bonus;

namespace TaskManager.DB.Repository.Bonus.PaymentClaimData
{
    public class PaymentClaimRepository : IPaymentClaimRepository
    {
        private readonly BonusConnection _bonusConnection;

        public PaymentClaimRepository(BonusConnection bonusConnection)
        {
            _bonusConnection = bonusConnection;
        }


        public IEnumerable<CreatePaymentClaimData> GetClaimsToCreate()
        {
            throw new NotImplementedException();
        }

        public bool CreateClaim(CreatePaymentClaimData paymentInfo, ref string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
