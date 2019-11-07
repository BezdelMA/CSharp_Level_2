using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayDay
{
    abstract class TypePay : IComparable
    {
        public int pay;
        public double multiPay;
        public string name;

        public TypePay(string name, int pay)
        {
            this.name = name;
            this.pay = pay;
        }
        public abstract void CalculationPay();

        public override string ToString()
        {
            return String.Format("Имя сотрудника: {0}\t\tЗарплата сотрудника: {1}", name, multiPay);
        }
        
        public int CompareTo(Object obj)
        {
            return multiPay.CompareTo((obj as TypePay).multiPay);
        }
    }
}

