
namespace Shop
{
    public interface IPresenter
    {
        string getFooter(double totalAmount, int totalBonus);
        string getHeader(Customer customer);
        string getItemRow(Item product, double price, double discount, double bonus);
    }
}
