using System;
namespace Shop
{
    public class GoodsFactory
    {
        public static Goods Create(string code, string name)
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
        }
    }
}
