using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Model.Allowance
{
    public class AllowanceCommand
    {
        public decimal CheckFund { get; internal set; }
        public decimal AnnualIncome { get; internal set; }
        public bool IsSpouse { get; internal set; }
        public int NumChildPayTax { get; internal set; }
        public int NumChildBefor2018 { get; internal set; }
        public int NumChild2018 { get; internal set; }
        public int Protege { get; internal set; }
        public int NumParental { get; internal set; }
        public int NumFamilyDisabled { get; internal set; }
        public bool IsOtherDisabled { get; internal set; }
        public decimal ParentalInsureFees { get; internal set; }
        public int NumCoParentalInsure { get; internal set; }
        public decimal LongevityInsurance { get; internal set; }
        public decimal LifeInsureFees { get; internal set; }
        public decimal SpouseLifeInsureFees { get; internal set; }
        public decimal HealthInsureFees { get; internal set; }
        public decimal ProvidentFund { get; internal set; }
        public decimal ExProvidentFund { get; internal set; }
        public decimal NationalFund { get; internal set; }
        public decimal PayRMF { get; internal set; }
        public decimal PayLTF { get; internal set; }
        public decimal PayInterestHouse { get; internal set; }
        public decimal NumCoBorrower { get; internal set; }
        public decimal FirstHouse2015Fee { get; internal set; }
        public decimal FirstHouse2019Fee { get; internal set; }
        public decimal SocialSecurityFee { get; internal set; }
        public decimal SecurityCameraFee { get; internal set; }
        public decimal AnnualIncomeExcentOneOrTwo { get; internal set; }
        public decimal CreditFee { get; internal set; }
        public decimal MainTown { get; internal set; }
        public decimal SubTown { get; internal set; }
        public decimal StartupFee { get; internal set; }
        public decimal AntenatalFee { get; internal set; }
        public decimal PoliticalPartyDonate { get; internal set; }
        public decimal TireFee { get; internal set; }
        public decimal BookFee { get; internal set; }
        public decimal OTOPFee { get; internal set; }
    }
}
