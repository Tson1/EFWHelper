using System.Globalization;

namespace ModleSale
{
    public partial class Orders
    {

        public override string ToString()
        {
            if(!CustomersReference.IsLoaded) CustomersReference.Load();
            return Qu(OrderID.ToString(CultureInfo.InvariantCulture)) + Qu(Customers.CustomerID) + Qu(OrderDate.ToString());
        }

        public string Qu(string str)
        {
            return "'" + str + "'";
        }
    }
}
