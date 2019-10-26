using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public double getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }

        public int getBonus()
        {
            return (int) (this.getGoods().getBonusRate() * getSum());           
        }

        public double getDiscount()
        {            
            return Math.Round(this.getGoods().getDiscountRate(this.getQuantity()) * getSum(), 2);            
        }

        public double getSum()
        {
            return this.getQuantity() * this.getPrice();
        }

        public int getUsedBonus(Customer _customer, double price)
        {
            int usedBonus = 0;
            if ((_Goods.GetType() == typeof(RegularGoods)) && _quantity > 5)
                usedBonus += _customer.useBonus((int)(price));
            if ((_Goods.GetType() == typeof(SpecialGoods)) && _quantity > 1)
                usedBonus += _customer.useBonus((int)(price));
            return usedBonus;
        }
    }
}
