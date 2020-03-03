using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            Goods cola = GoodsFactory.Create("REG", "Cola", DateTime.Parse("11.11.2019"));
            Goods pepsi = GoodsFactory.Create("SAL", "Pepsi", DateTime.Parse("11.11.2019"));
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            BillGenerator b1 = new BillGenerator(x, new TXTBuilder());
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.createBill();
            Console.WriteLine(bill);
        }
    }
}
