﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Strategy
{
    public interface ISaleStrategy
    {
        double GetDiscount(int quantity, double price);
    }
}
