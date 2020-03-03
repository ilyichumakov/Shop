using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLib
{
    public class TXTBuilder : IPresenter
    {
        public TXTBuilder() { }
        public string getHeader(Customer customer) // returns head of the bill table
        {
            String result = "Счет для " + customer.getName() + "\n";
            result += "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
            return result;
        }

        public string getFooter(double totalAmount, int totalBonus) // returns total block
        {
            String result = "Сумма счета составляет " + totalAmount.ToString() + "\n";
            result += "Вы заработали " + totalBonus.ToString() + " бонусных балов";
            return result;
        }

        public string getItemRow(Item product, double price, double discount, double bonus) // returns a string for product
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
