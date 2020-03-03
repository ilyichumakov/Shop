using System;
using ShopLib.Strategy;

namespace ShopLib
{
    public class Goods
    {
        protected IBonus _bonusStrategy;
        protected ISaleStrategy _saleStrategy;
        protected IUseBonusStrategy UseBonusStrategy;
        protected String _title;
        public ISaleStrategy SaleStrategy { get { return _saleStrategy; } }
        public IBonus BonusStrategy { get { return _bonusStrategy; } }

        public Goods(String title, IBonus b, ISaleStrategy s, IUseBonusStrategy u)
        {
            _title = title;
            _bonusStrategy = b;
            _saleStrategy = s;
            UseBonusStrategy = u;
        }
        public String getTitle()
        {
            return _title;
        } 
        
        /*
        public virtual double getBonusRate()
        {
            return 0;
        }*/

        public double getBonus(double price)
        {
            return _bonusStrategy.GetBonus(price);
        }

        /*public virtual double getDiscountRate(int quantity)
        {
            return 0;
        }*/

        public double getDiscount(int quantity, double price)
        {
            return _saleStrategy.GetDiscount(quantity, price);
        }

        public int GetUsedBonus(int quantity, double price, Customer customer)
        {
            return UseBonusStrategy.GetUsedBonus(quantity, price, customer);
        }
    }
}
