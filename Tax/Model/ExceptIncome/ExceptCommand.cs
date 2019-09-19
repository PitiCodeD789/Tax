using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.Model.ExceptIncome
{
    public class ExceptCommand
    {
        public decimal AnnaulIncome { get; set; }
        public decimal ProvidentFund { get; set; }
        public decimal GovermentFund { get; set; }
        public decimal TeacherAidFund { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsElderly { get; set; }
        public decimal UnemployFee { get; set; }
    }
}
