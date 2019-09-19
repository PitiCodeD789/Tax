using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model;
using Tax.Model.ExceptIncome;
using Tax.SubService;

namespace Tax
{
    public class MainTax
    {
        private readonly ExceptIncome _exceptIncome = new ExceptIncome();
        private readonly OtherService _otherService = new OtherService();
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
            mainValue.ExceptValue = exceptValue

            decimal incomeDifExcept = annualIncome - exceptResult.ExceptValue;
            mainValue.IncomeDifExcept = incomeDifExcept;

            decimal expensesAllo = Expenses(incomeDifExcept);
            mainValue.ExpensesAllo = expensesAllo;

            decimal incomeDifExpenses = incomeDifExcept - expensesAllo;
            mainValue.IncomeDifExpenses = incomeDifExpenses;

            decimal checkFund = exceptResult.CheckFund;

            throw new NotImplementedException();
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
