using System;
using System.IO;

namespace ShopLib
{
    public abstract class AbstractContentFile : IContentFile
    {
        protected string _source;
        public string Source { get { return this._source; } }
        protected TextReader sr;

        public void SetSource(string source)
        {
            this._source = source;
        }

        public Customer GetCustomer()
        {
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            string name = result[1].Trim();
            line = sr.ReadLine();
            result = line.Split(':');
            int bonus = Convert.ToInt32(result[1].Trim());
            return new Customer(name, bonus);
        }

        public int GetGoodsCount()
        {
            string line = sr.ReadLine();
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public Goods GetNextGood()
        {
            string line = "";
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            string[] result = line.Split(':');
            result = result[1].Trim().Split();
            string type = result[1].Trim();

            return GoodsFactory.Create(type, result[0]);
        }

        public int GetItemsCount()
        {
            string line = "";
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            string[] result = line.Split(':');
            return Convert.ToInt32(result[1].Trim());
        }

        public Item GetNextItem(Goods good)
        {
            string line = "";
            do
            {
                line = sr.ReadLine();
            } while (line.StartsWith("#"));
            string[] result = line.Split(':');
            result = result[1].Trim().Split();
            int gid = Convert.ToInt32(result[0].Trim());
            double price = Convert.ToDouble(result[1].Trim());
            int qty = Convert.ToInt32(result[2].Trim());
            return new Item(good, qty, price);
        }
    }
}
