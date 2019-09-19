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
    }
}
