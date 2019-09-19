using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Model
{
    public class MainValueModel
    {
        public decimal AnnaulIncome { get; set; }
        public decimal ExceptValue { get; set; }
        public decimal IncomeDifExcept { get; set; }
        public decimal ExpensesAllo { get; set; }
        public decimal IncomeDifExpenses { get; set; }
        public decimal AllowanceValue { get; set; }
        public decimal IncomeDifAllowance { get; set; }
        public decimal DonateSpValue { get; set; }
        public decimal IncomeDifDonateSp { get; set; }
        public decimal DonateValue { get; set; }
        public decimal IncomeDifDonate { get; set; }
        public decimal FirstTax { get; set; }
    }
}
