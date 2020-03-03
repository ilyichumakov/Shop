using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public class FixedBonusUsage : IUseBonusStrategy
    {
        int Amount { get; set; } 
        public FixedBonusUsage(int amount)
        {
            Amount = amount;
        }

        public int GetUsedBonus(int quantity, double price, Customer customer) => Amount;

    }
}
