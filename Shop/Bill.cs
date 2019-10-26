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
                
                int bonus = each.getBonus();
                double discount = each.getDiscount();                                 
                
                double thisAmount = each.getQuantity() * each.getPrice() - discount; // total price for this item                
                thisAmount -= each.getUsedBonus(_customer, thisAmount);

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
                "\t" + (product.getSum()).ToString() +
                "\t" + discount.ToString() + "\t" + price.ToString() +
                "\t" + bonus.ToString() + "\n";
            return result;
        }
    }
}
