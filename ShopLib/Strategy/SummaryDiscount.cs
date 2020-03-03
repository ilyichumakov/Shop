using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Strategy
{
    public class SummaryDiscount : ISaleStrategy
    {
        private double _targetPrice { get; set; }
        private double _percent { get; set; }

        public SummaryDiscount(double finalPrice, double percent)
        {
            _targetPrice = finalPrice;
            this._percent = percent;
        }

        public double GetDiscount(int quantity, double price)
        {
            double discount = 0;
            if (price >= _targetPrice)
                discount = (price * quantity) * _percent;

            return discount;
        }
    }

}
