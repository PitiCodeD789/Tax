using System;
using Tax;
using Tax.Model;

namespace TestTax
{
    class Program
    {
        static void Main(string[] args)
        {
            MainTax mainTax = new MainTax();
            TaxCommand command = new TaxCommand()
            {
                 AnnaulIncome = 100000000,
                 WorkThai = true,
                 StatusStayThai = true,
                 ProvidentFund = 0,
                 GovermentFund = 0,
                 TeacherAidFund = 0,
                 IsDisabled = false,
                 IsElderly = false,
                 UnemployFee = 0,
                 IsSpouse = false,
                 NumChildPayTax = 0,
                 NumChildBefor2018 = 0,
                 NumChild2018 = 0,
                 Protege = 0,
                 NumParental = 0,
                 NumFamilyDisabled = 0,
                 IsOtherDisabled = false,
                 ParentalInsureFees = 0,
                 NumCoParentalInsure = 0,
                 LongevityInsurance = 0,
                 LifeInsureFees = 0,
                 SpouseLifeInsureFees = 0,
                 HealthInsureFees = 0,
                 ExProvidentFund = 0,
                 NationalFund = 0,
                 PayRMF = 0,
                 PayLTF = 0,
                 PayInterestHouse = 0,
                 NumCoBorrower = 0,
                 FirstHouse2015Fee = 0,
                 FirstHouse2019Fee = 0,
                 SocialSecurityFee = 0,
                 SecurityCameraFee = 0,
                 AnnualIncomeExcentOneOrTwo = 0,
                 CreditFee = 0,
                 MainTown = 0,
                 SubTown = 0,
                 StartupFee = 0,
                 AntenatalFee = 0,
                 PoliticalPartyDonate = 0,
                 TireFee = 0,
                 BookFee = 0,
                 OTOPFee = 0,
                 DonateSpFee = 0,
                 DonateFee = 0,
            };
            var result = mainTax.MainCalculate(command);
            Console.WriteLine("First Page :");
            Console.WriteLine("AnnaulIncome : " + result.MainValue.AnnaulIncome.ToString("#,##0.00"));
            Console.WriteLine("ExceptValue : " + result.MainValue.ExceptValue.ToString("#,##0.00"));
            Console.WriteLine("IncomeDifExcept : " + result.MainValue.IncomeDifExcept.ToString("#,##0.00"));
            Console.WriteLine("ExpensesAllo : " + result.MainValue.ExpensesAllo.ToString("#,##0.00"));
            Console.WriteLine("IncomeDifExpenses : " + result.MainValue.IncomeDifExpenses.ToString("#,##0.00"));
            Console.WriteLine("AllowanceValue : " + result.MainValue.AllowanceValue.ToString("#,##0.00"));
            Console.WriteLine("IncomeDifAllowance : " + result.MainValue.IncomeDifAllowance.ToString("#,##0.00"));
            Console.WriteLine("DonateSpValue : " + result.MainValue.DonateSpValue.ToString("#,##0.00"));
            Console.WriteLine("IncomeDifDonateSp : " + result.MainValue.IncomeDifDonateSp.ToString("#,##0.00"));
            Console.WriteLine("DonateValue : " + result.MainValue.DonateValue.ToString("#,##0.00"));
            Console.WriteLine("IncomeDifDonate : " + result.MainValue.IncomeDifDonate.ToString("#,##0.00"));
            Console.WriteLine("First Tax : " + result.MainValue.FirstTax.ToString("#,##0.00"));
            Console.WriteLine("\n---------------------------------------------------------------------------------\n");
            Console.WriteLine("Second Page :");
            Console.WriteLine("First Tax : " + result.MainValue.FirstTax.ToString("#,##0.00"));
        }
    }
}
