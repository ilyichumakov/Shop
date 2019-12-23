using System;
using System.IO;
namespace Shop
{
    public class YAMLFile : AbstractContentFile
    {
        public YAMLFile(TextReader sr, string path)
        {
            this.sr = sr;
            this._source = path;
        }

        public YAMLFile(TextReader sr)
        {
            this.sr = sr;
        }

        public BillGenerator getData(IPresenter presenter)
        {
            Customer customer = GetCustomer();
            BillGenerator b = new BillGenerator(customer, presenter);
            int cnt = GetGoodsCount();
            Goods[] g = new Goods[cnt];
            for (int i = 0; i < cnt; i++)
            {
                g[i] = GetNextGood();
            }
            int itemsQty = GetItemsCount();
            for (int i = 0; i < itemsQty; i++)
            {
                b.addGoods(GetNextItem(g[i]));
            }
            return b;
        }
    }
}
