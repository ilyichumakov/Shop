using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Strategy
{
    public interface IBonus
    {
        int GetBonus(double price);
    }
}
