using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDay
{
    class HourlyWage : TypePay
    {
        public HourlyWage (string name, int pay) : base(name, pay)
        {
            
        }

        public override void CalculationPay()
        {
            multiPay = 20.8 * 8 * pay;
        }
    }
}
