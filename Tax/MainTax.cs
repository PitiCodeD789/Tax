using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model;
using Tax.Model.Allowance;
using Tax.Model.ExceptIncome;
using Tax.SubService;

namespace Tax
{
    public class MainTax
    {
        private readonly ExceptIncome _exceptIncome = new ExceptIncome();
        private readonly OtherService _otherService = new OtherService();
        private readonly Allowance _allowance = new Allowance();
        public ResultModel MainCalculate(TaxCommand command)
        {
            decimal annualIncome = command.AnnaulIncome;
            bool workThai = command.WorkThai;
            bool statusStayThai = command.StatusStayThai; //"true" is Stay in thai less than 180 day in that year
            if (InspectTaxPayer(annualIncome, workThai, statusStayThai))
            {
                return new ResultModel()
                {
                    Success = false,
                    Message = "No Tex Filing"
                };
            }
            MainValueModel mainValue = new MainValueModel()
            {
                AnnaulIncome = annualIncome
            };

            decimal providentFund = command.ProvidentFund;
            decimal govermentFund = command.GovermentFund;
            decimal teacherAidFund = command.TeacherAidFund;
            bool isDisabled = command.IsDisabled;
            bool isElderly = command.IsElderly;
            decimal unemployFee = command.UnemployFee;
            ExceptCommand exceptCommand = new ExceptCommand()
            {
                AnnaulIncome = annualIncome,
                ProvidentFund = providentFund,
                GovermentFund = govermentFund,
                TeacherAidFund = teacherAidFund,
                IsDisabled = isDisabled,
                IsElderly = isElderly,
                UnemployFee = unemployFee,
            };
            var exceptResult = _exceptIncome.MainCalculate(exceptCommand);
            decimal exceptValue = _otherService.MoreThan(exceptResult.ExceptValue, annualIncome);
            mainValue.ExceptValue = exceptValue;

            decimal incomeDifExcept = annualIncome - exceptResult.ExceptValue;
            mainValue.IncomeDifExcept = incomeDifExcept;

            decimal expensesAllo = Expenses(incomeDifExcept);
            mainValue.ExpensesAllo = expensesAllo;

            decimal incomeDifExpenses = incomeDifExcept - expensesAllo;
            mainValue.IncomeDifExpenses = incomeDifExpenses;

            decimal checkFund = exceptResult.CheckFund;
            AllowanceCommand allowanceCommand = new AllowanceCommand()
            {
                 CheckFund = checkFund,
                 AnnualIncome = annualIncome,
                 IsSpouse = command.IsSpouse,
                 NumChildPayTax = command.NumChildPayTax,
                 NumChildBefor2018 = command.NumChildBefor2018,
                 NumChild2018 = command.NumChild2018,
                 Protege = command.Protege,
                 NumParental = command.NumParental,
                 NumFamilyDisabled = command.NumFamilyDisabled,
                 IsOtherDisabled = command.IsOtherDisabled,
                 ParentalInsureFees = command.ParentalInsureFees,
                 NumCoParentalInsure = command.NumCoParentalInsure,
                 LongevityInsurance = command.LongevityInsurance,
                 LifeInsureFees = command.LifeInsureFees,
                 SpouseLifeInsureFees = command.SpouseLifeInsureFees,
                 HealthInsureFees = command.HealthInsureFees,
                 ProvidentFund = command.ProvidentFund,
                 ExProvidentFund = command.ExProvidentFund,
                 NationalFund = command.NationalFund,
                 PayRMF = command.PayRMF,
                 PayLTF = command.PayLTF,
                 PayInterestHouse = command.PayInterestHouse,
                 NumCoBorrower = command.NumCoBorrower,
                 FirstHouse2015Fee = command.FirstHouse2015Fee,
                 FirstHouse2019Fee = command.FirstHouse2019Fee,
                 SocialSecurityFee = command.SocialSecurityFee,
                 SecurityCameraFee = command.SecurityCameraFee,
                 AnnualIncomeExcentOneOrTwo = command.AnnualIncomeExcentOneOrTwo,
                 CreditFee = command.CreditFee,
                 MainTown = command.MainTown,
                 SubTown = command.SubTown,
                 StartupFee = command.StartupFee,
                 AntenatalFee = command.AntenatalFee,
                 PoliticalPartyDonate = command.PoliticalPartyDonate,
                 TireFee = command.TireFee,
                 BookFee = command.BookFee,
                 OTOPFee = command.OTOPFee
            };
            var allowanceResult = _allowance.MainAllowance(allowanceCommand);
            decimal allowanceValue = _otherService.MoreThan(allowanceResult.AllowanceValue, incomeDifExpenses);
            mainValue.AllowanceValue = allowanceValue;

            decimal incomeDifAllowance = incomeDifExpenses - allowanceValue;
            mainValue.IncomeDifAllowance = incomeDifAllowance;

            decimal donateSpFee = command.DonateSpFee;
            decimal donateSpValue = DonateSp(incomeDifAllowance, donateSpFee);
            mainValue.DonateSpValue = donateSpValue;

            decimal incomeDifDonateSp = incomeDifAllowance - donateSpValue;
            mainValue.IncomeDifDonateSp = incomeDifDonateSp;

            decimal donateFee = command.DonateFee;
            decimal donateValue = Donate(incomeDifDonateSp, donateFee);
            mainValue.DonateValue = donateValue;

            decimal incomeDifDonate = incomeDifDonateSp - donateValue;
            mainValue.IncomeDifDonate = incomeDifDonate;

            decimal firstTax = CalculateTax(incomeDifDonate);
            mainValue.FirstTax = firstTax;

            ResultModel resultModel = new ResultModel()
            {
                Success = true,
                Message = "Data Tax Success",
                ExceptResult = exceptResult,
                AllowanceResult = allowanceResult,
                MainValue = mainValue
            };

            return resultModel;
        }

        public decimal CalculateTax(decimal incomeDifDonate)
        {
            decimal firstTax = 0;
            if (incomeDifDonate > 5000000)
            {
                firstTax = (incomeDifDonate - 5000000) * 0.35m + 1265000;
            }
            else if(incomeDifDonate > 2000000)
            {
                firstTax = (incomeDifDonate - 2000000) * 0.3m + 365000;
            }
            else if (incomeDifDonate > 1000000)
            {
                firstTax = (incomeDifDonate - 1000000) * 0.25m + 115000;
            }
            else if (incomeDifDonate > 750000)
            {
                firstTax = (incomeDifDonate - 7500000) * 0.2m + 65000;
            }
            else if (incomeDifDonate > 500000)
            {
                firstTax = (incomeDifDonate - 500000) * 0.15m + 27500;
            }
            else if (incomeDifDonate > 300000)
            {
                firstTax = (incomeDifDonate - 300000) * 0.1m + 7500;
            }
            else if (incomeDifDonate > 150000)
            {
                firstTax = (incomeDifDonate - 150000) * 0.05m;
            }
            else
            {
                firstTax = 0;
            }
            return firstTax;
        }

        private decimal Donate(decimal incomeDifDonateSp, decimal donateFee)
        {
            decimal limitPercent = 0.1m;
            decimal donateValue = _otherService.MoreThan(donateFee, incomeDifDonateSp * limitPercent);
            return donateValue;
        }

        public decimal DonateSp(decimal incomeDifAllowance, decimal donateSpFee)
        {
            decimal limitPercent = 0.1m;
            decimal donateSpValue = _otherService.MoreThan(donateSpFee * 2, incomeDifAllowance * limitPercent);
            return donateSpValue;
        }

        public decimal Expenses(decimal incomeDifExcept)
        {
            decimal limitExpenses = 100000;
            decimal expensesAllo = incomeDifExcept * 0.5m;
            if(expensesAllo > limitExpenses)
            {
                expensesAllo = limitExpenses;
            }
            return expensesAllo;
        }

        public bool InspectTaxPayer(decimal annualIncome, bool workThai, bool statusStayThai)
        {
            if(annualIncome > 120000 && (workThai || statusStayThai))
            {
                return false;
            }
            return true;
        }
    }
}
