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
    }
}
