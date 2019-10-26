using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class HTMLBuilder : IPresenter
    {
        public HTMLBuilder() { }
        public string getHeader(Customer customer) // returns head of the bill table
        {
            String result = "<table><thead><tr><td colspan='7'>Счет для " + customer.getName() + "</td>";
            result += "<td>" + "Название" + "</td><td>" + "Цена" +
            "</td><td>" + "Кол-во" + "</td><td>" + "Стоимость" + "</td><td>" + "Скидка" +
            "</td><td>" + "Сумма" + "</td><td>" + "Бонус" + "</td></tr></thead><tbody>";
            return result;
        }

        public string getFooter(double totalAmount, int totalBonus) // returns total block
        {
            String result = "</tbody><tfoot><tr><td colspan='4'>Сумма счета составляет " + totalAmount.ToString() + "</td><td>";
            result += "</td><td colspan='3'>Вы заработали " + totalBonus.ToString() + " бонусных балов</td></tr></tfoot></table>";
            return result;
        }

        public string getItemRow(Item product, double price, double discount, double bonus) // returns a string for product
        {
            String result = "<tr><td>" + product.getGoods().getTitle() + "</td><td>" +
               product.getPrice() + "</td><td>" + product.getQuantity() +
                "</td><td>" + (product.getSum()).ToString() +
                "</td><td>" + discount.ToString() + "</td><td>" + price.ToString() +
                "</td><td>" + bonus.ToString() + "</td></tr>";
            return result;
        }
    }
}
