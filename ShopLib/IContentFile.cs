using System;
namespace ShopLib
{
    public interface IContentFile
    {
        void SetSource(string source);
        Customer GetCustomer();
        int GetGoodsCount();
        Goods GetNextGood();
        int GetItemsCount();
        Item GetNextItem(Goods good);
    }
}
