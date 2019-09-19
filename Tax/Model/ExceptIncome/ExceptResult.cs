using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Model.ExceptIncome
{
    public class ExceptResult
    {
        public decimal ExceptValue { get; set; }
        public decimal ExProvidentFund { get; set; }
        public decimal ExGovernmentFund { get; set; }
        public decimal ExTeacherAidFund { get; set; }
        public decimal ExceptElderly { get; set; }
        public decimal ExUnemployFee { get; set; }
        public decimal CheckFund { get; set; }
    }
}
