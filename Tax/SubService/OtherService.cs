using System;
using System.Collections.Generic;
using System.Text;

namespace Tax.SubService
{
    public class OtherService
    {
        public decimal MoreThan(decimal value, decimal limit)
        {
            if (value > limit)
            {
                value = limit;
            }
            return value;
        }
    }
}
