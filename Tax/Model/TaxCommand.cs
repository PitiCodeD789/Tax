using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Model
{
    public class TaxCommand
    {
        public decimal AnnaulIncome { get; set; }
        public bool WorkThai { get; set; }
        public bool StatusStayThai { get; set; }
        public decimal ProvidentFund { get; set; }
        public decimal GovermentFund { get; set; }
        public decimal TeacherAidFund { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsElderly { get; set; }
        public decimal UnemployFee { get; set; }
        public bool IsSpouse { get; set; }
        public int NumChildPayTax { get; set; }
        public int NumChildBefor2018 { get; set; }
        public int NumChild2018 { get; set; }
        public int Protege { get; set; }
        public int NumParental { get; set; }
        public int NumFamilyDisabled { get; set; }
        public bool IsOtherDisabled { get; set; }
        public decimal ParentalInsureFees { get; set; }
        public int NumCoParentalInsure { get; set; }
        public decimal LongevityInsurance { get; set; }
        public decimal LifeInsureFees { get; set; }
        public decimal SpouseLifeInsureFees { get; set; }
        public decimal HealthInsureFees { get; set; }
        public decimal ExProvidentFund { get; set; }
        public decimal NationalFund { get; set; }
        public decimal PayRMF { get; set; }
        public decimal PayLTF { get; set; }
        public decimal PayInterestHouse { get; set; }
        public decimal NumCoBorrower { get; set; }
        public decimal FirstHouse2015Fee { get; set; }
        public decimal FirstHouse2019Fee { get; set; }
        public decimal SocialSecurityFee { get; set; }
        public decimal SecurityCameraFee { get; set; }
        public decimal AnnualIncomeExcentOneOrTwo { get; set; }
        public decimal CreditFee { get; set; }
        public decimal MainTown { get; set; }
        public decimal SubTown { get; set; }
        public decimal StartupFee { get; set; }
        public decimal AntenatalFee { get; set; }
        public decimal PoliticalPartyDonate { get; set; }
        public decimal TireFee { get; set; }
        public decimal BookFee { get; set; }
        public decimal OTOPFee { get; set; }
        public decimal DonateSpFee { get; set; }
        public decimal DonateFee { get; set; }
    }
}
