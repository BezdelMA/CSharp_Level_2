using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDay
{
    class FixPrice : TypePay
    {
        public FixPrice(string name, int pay) : base (name, pay)
        {
            
        }

        public override void CalculationPay()
        {
            multiPay = Convert.ToDouble(pay);
        }
    }
}
