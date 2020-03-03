using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public class FixedBonus : IBonus
    {
        private double _percent { get; set; }
        public FixedBonus(double percent)
        {
            _percent = percent;
        }
        public int GetBonus(double price)
        {
            return (int)(price * _percent);
        }
    }

}
