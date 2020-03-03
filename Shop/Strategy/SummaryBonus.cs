using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public class SummaryBonus : IBonus
    {
        private double _targetPrice { get; set; }
        private double _percent { get; set; }
        public SummaryBonus(double finalPrice, double percent)
        {
            _targetPrice = finalPrice;
            _percent = percent;
        }
        public int GetBonus(double price)
        {
            if (price >= _targetPrice)
                return (int)(price * _percent);
            return 0;
        }
    }
}
