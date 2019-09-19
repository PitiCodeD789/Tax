using System;
using System.Collections.Generic;
using System.Text;
using Tax.Model.Allowance;
using Tax.Model.ExceptIncome;

namespace Tax.Model
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ExceptResult ExceptResult { get; set; }
        public AllowanceResult AllowanceResult { get; set; }
        public MainValueModel MainValue { get; set; }
    }
}
