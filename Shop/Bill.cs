using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public String statement()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = GetHeader();
            while (items.MoveNext())
            {       
                Item each = (Item)items.Current;
                
                int bonus = getBonus(each);
                double discount = getDiscount(each);   // count bonuses and discount for this item                                
                
                double thisAmount = each.getQuantity() * each.getPrice() - discount; // total price for this item
                thisAmount -= getUsedBonus(each, thisAmount);

                // accumulate a string describing prosuct row in bill
                result += GetItemRow(each, thisAmount, discount, bonus); 
                
                totalAmount += thisAmount; //accumulate total price
                totalBonus += bonus; // accumulate total bonuses
            }
            result += GetFooter(totalAmount, totalBonus); // show total block in bill
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }

        private int getBonus(Item product)
        {
            int bonus = 0;
            switch (product.getGoods().getPriceCode())
            {
                case Goods.REGULAR:                    
                    bonus =
                    (int)(getSum(product) * 0.05);
                    break;                
                case Goods.SALE:                    
                    bonus =
                    (int)(getSum(product) * 0.01);
                    break;
                default:
                    break;
            }
            return bonus;
        }

        private double getDiscount(Item product)
        {
            double discount = 0;
            switch (product.getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (product.getQuantity() > 2)
                        discount = Math.Round((getSum(product)) * 0.03, 2); // 3%
                    
                    break;
                case Goods.SPECIAL_OFFER:
                    if (product.getQuantity() > 10)
                        discount = Math.Round((getSum(product)) * 0.005, 2); // 0.5%
                    break;
                case Goods.SALE:
                    if (product.getQuantity() > 3)
                        discount = Math.Round((getSum(product)) * 0.01, 2); // 0.1%                   
                    break;
                default:
                    break;
            }

            //discount += getUsedBonus(product);

            return discount;
        }

        private int getUsedBonus(Item product, double price)
        {
            int usedBonus = 0;
            if ((product.getGoods().getPriceCode() == Goods.REGULAR) && product.getQuantity() > 5)
                usedBonus += _customer.useBonus((int)(price));
            if ((product.getGoods().getPriceCode() == Goods.SPECIAL_OFFER) && product.getQuantity() > 1)
                usedBonus += _customer.useBonus((int)(price));
            return usedBonus;
        }

        private double getSum(Item product)
        {
            return product.getQuantity() * product.getPrice();
        }

        private string GetHeader() // returns head of the bill table
        {
            String result = "Счет для " + _customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }

        private string GetFooter(double totalAmount, int totalBonus) // returns total block
        {
            String result = "Сумма счета составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }

        private string GetItemRow(Item product, double price, double discount, double bonus) // returns a string for product
        {
            String result = "\t" + product.getGoods().getTitle() + "\t" +
                "\t" + product.getPrice() + "\t" + product.getQuantity() +
                "\t" + (getSum(product)).ToString() +
                "\t" + discount.ToString() + "\t" + price.ToString() +
                "\t" + bonus.ToString() + "\n";
            return result;
        }
    }
}
