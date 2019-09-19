using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model.ExceptIncome;

namespace Tax.SubService
{
    public class ExceptIncome
    {
        private decimal checkFund;
        public decimal CheckFund
        {
            get { return checkFund; }
            set { checkFund = value; }
        }

        public ExceptIncome()
        {
            checkFund = 500000;
        }

        public ExceptResult MainCalculate(ExceptCommand command)
        {
            decimal annualIncome = command.AnnaulIncome;
            decimal providentFund = command.ProvidentFund;
            decimal govermentFund = command.GovermentFund;
            decimal teacherAidFund = command.TeacherAidFund;
            bool isDisabled = command.IsDisabled;
            bool isElderly = command.IsElderly;
            decimal unemployFee = command.UnemployFee;
            decimal exProvidentFund = AdaptProvident(annualIncome, providentFund);
            decimal exGovernmentFund = AdaptOtherValue(govermentFund);
            decimal exTeacherAidFund = AdaptOtherValue(teacherAidFund);
            decimal exceptElderly = DisabledAndElderly(isDisabled, isElderly);
            decimal exUnemployFee = AdaptUnemploy(unemployFee);
            decimal exceptValue = exProvidentFund + exGovernmentFund + exTeacherAidFund + exceptElderly + exUnemployFee;
            ExceptResult exceptResult = new ExceptResult()
            {
                ExceptValue = exceptValue,
                ExProvidentFund = exProvidentFund,
                ExGovernmentFund = exGovernmentFund,
                ExTeacherAidFund = exTeacherAidFund,
                ExceptElderly = exceptElderly,
                ExUnemployFee = exUnemployFee,
                CheckFund = checkFund
            };
            return exceptResult;
        }

        public decimal AdaptUnemploy(decimal unemployFee)
        {
            decimal limitUmemploy = 300000;
            if(unemployFee > limitUmemploy)
            {
                unemployFee = limitUmemploy;
            }
            return unemployFee;
        }

        public decimal DisabledAndElderly(bool isDisabled, bool isElderly)
        {
            if(isDisabled || isElderly)
            {
                return 190000;
            }
            return 0;
        }

        public decimal AdaptOtherValue(decimal value)
        {
            if (value > checkFund)
            {
                value = checkFund;
            }
            checkFund -= value;
            return value;
        }

        public decimal AdaptProvident(decimal annualIncome, decimal providentFund)
        {
            decimal limitProvident = 0.15m;
            if (providentFund > annualIncome * limitProvident)
            {
                providentFund = annualIncome * limitProvident;
            }
            if (providentFund > checkFund)
            {
                providentFund = checkFund;
            }
            checkFund -= providentFund;
            return providentFund;
        }
    }
}
