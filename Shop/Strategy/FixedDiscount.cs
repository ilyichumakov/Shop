using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public class FixedDiscount : ISaleStrategy
    {
        private double percent { get; set; }

        public FixedDiscount(double percent)
        {
            this.percent = percent;
        }

        public double GetDiscount(int quantity, double price)
        {
            return (price * quantity) * percent;
        }
    }
}
