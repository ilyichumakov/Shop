using System;
using ShopLib.Strategy;

namespace ShopLib
{
    public class GoodsFactory
    {
        /*public static Goods Create(string code, string name)
        {
            switch(code){
                case "REG":
                    return new RegularGoods(name);
                    break;
                case "SAL":
                    return new SalesGoods(name);
                    break;
                case "SPO":
                    return new SpecialGoods(name);
                    break;
                default:
                    throw new ArgumentException("We haven't such type of good yet");
                    break;
            }
           
        }*/
        public static Goods Create(string code, string name)
        {
            DateTime current = DateTime.Now;
            return TimeCreate(code, name, current);
        }

        public static Goods Create(string code, string name, DateTime date)
        {
            DateTime current = date;
            
            return TimeCreate(code, name, current);
        }

        private static Goods TimeCreate(string code, string name, DateTime date)
        {
            DateTime current = date;
            DateTime newYear = new DateTime(current.Year + 1, 1, 1);
            var difference = (newYear - current).Duration();
            Goods goods;
            if (difference.Days > 14)
            {
                goods = defaultCreate(code, name);
            }
            else
            {
                goods = NewYearCreate(code, name);
            }
            return goods;
        }

        private static Goods defaultCreate(string code, string name)
        {
            ISaleStrategy discountStrategy;
            IBonus bonusStrategy;
            IUseBonusStrategy usedBonusStrategy;
            switch (code)
            {
                case "REG":
                    discountStrategy = new QuantityDiscount(2, 0.03);
                    bonusStrategy = new FixedBonus(0.05);
                    usedBonusStrategy = new UseQuantityBonus(5);
                    break;
                case "SAL":
                    discountStrategy = new QuantityDiscount(3, 0.01);
                    bonusStrategy = new FixedBonus(0.01);
                    usedBonusStrategy = new FixedBonusUsage(0);
                    break;
                case "SPO":
                    discountStrategy = new QuantityDiscount(10, 0.005);
                    bonusStrategy = new FixedBonus(0);
                    usedBonusStrategy = new UseQuantityBonus(1);
                    break;
                default:
                    throw new ArgumentException("We haven't such type of good yet");
            }
            return new Goods(name, bonusStrategy, discountStrategy, usedBonusStrategy);
        }
        private static Goods NewYearCreate(string code, string name)
        {
            ISaleStrategy discountStrategy;
            IBonus bonusStrategy;
            IUseBonusStrategy usedBonusStrategy;
            switch (code)
            {
                case "REG":
                    discountStrategy = new QuantityDiscount(2, 0.03);
                    bonusStrategy = new SummaryBonus(5000, 0.07);
                    usedBonusStrategy = new UseQuantityBonus(5);
                    break;
                case "SAL":
                    discountStrategy = new SummaryDiscount(2000, 0.03);
                    bonusStrategy = new FixedBonus(0.01);
                    usedBonusStrategy = new FixedBonusUsage(0);
                    break;
                case "SPO":
                    discountStrategy = new SummaryDiscount(3000, 0.05);
                    bonusStrategy = new FixedBonus(0);
                    usedBonusStrategy = new UseQuantityBonus(1);
                    break;
                default:
                    throw new ArgumentException("Incorrext id");
            }

            return new Goods(name, bonusStrategy, discountStrategy, usedBonusStrategy);
        }

    }
}
