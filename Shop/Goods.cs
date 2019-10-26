using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Goods
    {
  
        protected String _title;
        
        public Goods(String title)
        {
            _title = title;                      
        }
        public String getTitle()
        {
            return _title;
        }         
        public virtual double getBonusRate()
        {
            return 0;
        }

        public virtual double getDiscountRate(int quantity)
        {
            return 0;
        }
    }
}
