using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Strategy
{
    public interface IUseBonusStrategy
    {
        int GetUsedBonus(int quantity, double price, Customer customer);
    }
}
