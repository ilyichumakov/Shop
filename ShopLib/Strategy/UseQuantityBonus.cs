using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib.Strategy
{

    class UseQuantityBonus : IUseBonusStrategy
    {
        int ExpectedQuantity { get; set; }
        public UseQuantityBonus(int finalQuantity)
        {
            ExpectedQuantity = finalQuantity;
        }
        public int GetUsedBonus(int quantity, double price, Customer customer)
        {
            if (quantity > ExpectedQuantity)
                return customer.useBonus((int)(price));
            else
                return 0;
        }
    }

}
