using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model.POCO
{
    public class Policy
    {
        public string BonusType { get; set; }
        public int? BonusTypeGroupId { get; set; }
        public string PartnerMcsCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerType { get; set; }
        public string CustomerTypeId { get; set; }
        public string ConditionCode { get; set; }
        public string ConditionTitle { get; set; }

        public string FirstRewardPolicyCode { get; set; }
        public string SecondRewardPolicyCode { get; set; }
        public string SalesProgram { get; set; }

        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        public int? PolicyProductId { get; set; }
        public int? PolicyChannelId { get;set; }
        public int? RootPolicyChannelId { get; set; }
        public int StageId { get; set; }
        public string StageName { get; set; }
        public decimal? BudgetAmountT { get; set; }
        public decimal? FinalAmountT { get; set; }
        public decimal? FinalAmountL { get; set; }
        public decimal? CalculatedAmountT { get; set; }
        public DateTime? StageDate { get; set; }
        public int CalculationId { get; set; }
        public string CurrencyT { get; set; }
        public int PartnerId { get; set; }
        public int? BonusTypeId { get; set; }
        public int ClaimTypeId { get; set; }
        public string RefCode { get; set; }
        public string RefCodeName { get; set; }
        public string TargetType { get; set; }
        public string TargetMode { get; set; }
        public string ContactPerson { get; set; }
        public string DivCode { get; set; }
        public string DivName { get; set; }
        public string StageComment { get; set; }
        public string Period { get; set; }
        public string SubsidiaryCd { get; set; }
        public string DocumentType { get; set; }
        public string PaymentType { get; set; }
        public string PaymentClaimCode { get; set; }
        public DateTime? PaymentExpectedDate { get; set; }
        public bool HasSignedDocument { get; set; }
        public string Psdat { get; set; }
        public string Pedat { get; set; }
        public string ActualRewardPolicyCode { get; set; }
        
    }
}
