using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class BillGenerator
    {
        private List<Item> _items;
        private Customer _customer;
        private IPresenter _p;
        public BillGenerator(Customer customer, IPresenter view)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this._p = view;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }

        public void setPresenter(IPresenter view)
        {
            this._p = view;
        }

        public String createBill()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = _p.getHeader(_customer);
            while (items.MoveNext())
            {       
                Item each = (Item)items.Current;
                
                int bonus = each.getBonus();
                double discount = each.getDiscount();                                 
                
                double thisAmount = each.getQuantity() * each.getPrice() - discount; // total price for this item                
                thisAmount -= each.getUsedBonus(_customer, thisAmount);

                // accumulate a string describing prosuct row in bill
                result += _p.getItemRow(each, thisAmount, discount, bonus); 
                
                totalAmount += thisAmount; //accumulate total price
                totalBonus += bonus; // accumulate total bonuses
            }
            result += _p.getFooter(totalAmount, totalBonus); // show total block in bill
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }
       
    }
}
