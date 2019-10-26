using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }

        public double getBonusRate()
        {
            double bonus = 0;
            switch (_priceCode)
            {
                case Goods.REGULAR:
                    bonus = 0.05;
                    break;
                case Goods.SALE:
                    bonus = 0.01;
                    break;
                default:
                    break;
            }
            return bonus;
        }

        public double getDiscountRate(int quantity)
        {
            double rate = 0;
            switch (_priceCode)
            {
                case Goods.REGULAR:
                    if(quantity > 2) rate = 0.03;
                    break;
                case Goods.SALE:
                    if (quantity > 3) rate = 0.01;
                    break;
                case Goods.SPECIAL_OFFER:
                    if (quantity > 10) rate = 0.005;
                    break;
                default:
                    break;
            }
            return rate;
        }
    }
}
