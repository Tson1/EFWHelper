using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ModleSale
{
    public partial class Orders
    {
        public override string ToString()
        {
            return Qu(OrderID.ToString(CultureInfo.InvariantCulture)) + Qu(Customers.CustomerID) + Qu(OrderDate.ToString());
        }

        public string Qu(string str)
        {
            return "'" + str + "'";
        }
    }
}
