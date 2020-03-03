using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public class QuantityDiscount : ISaleStrategy
    {
        private int _targetQuantity { get; set; }
        private double _percent { get; set; }

        public QuantityDiscount(int targetQuantity, double percent)
        {
            _targetQuantity = targetQuantity;
            _percent = percent;
        }

        public double GetDiscount(int quantity, double price)
        {
            double discount = 0;
            if (quantity >= _targetQuantity)
                discount = price * quantity * _percent;

            return discount;
        }
    }
}
