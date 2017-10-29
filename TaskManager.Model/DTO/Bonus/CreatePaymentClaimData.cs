using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model.DTO.Bonus
{
    public class CreatePaymentClaimData
    {
        public int CalculationId { get; set; }
        public int PolicyChannelId { get; set; }
        public int StageId { get; set; }        
    }
}
