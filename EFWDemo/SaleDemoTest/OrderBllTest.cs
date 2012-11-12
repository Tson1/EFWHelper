using System.Diagnostics;
using System.Linq;
using ModleSale;
using NUnit.Framework;
using SaleBll;
using EFWComBll;
namespace SaleDemoTest
{
    [TestFixture]
    public class OrderBllTest
    {
        [Test]
        public void CanGetAllOrder()
        {
            var bll = new OrderBll { DbContext = new NorthWindEntities() };

            var ls = bll.Items.ToList();
            foreach (var order in ls)
            {
                order.CustomersReference.Load();//!!!!!!!!!!!!!!!重要！！！Lazy Loadであり、自動参照出来ない！
                Debug.WriteLine(order);
            }

            foreach (var orderse in ls)
            {
                orderse.CustomersReference.Load();
                Debug.WriteLine(orderse.Customers);

            }
        }
        [Test]
        public void CanGetAllOrderAutoLoad()
        {
            //3.5はできない！！！！！

        }
        [Test]
        public void CanGetAllOrderOneLine()
        {
            ////Lazy Loadのデータを取得パスで取得
            var bll = new OrderBll { DbContext = new NorthWindEntities() };
            var ls = from u in bll.Items.Include("Customers")
                     select u;

            foreach (var order in ls)
            {
                Debug.WriteLine(order);
            }
        }
        [Test]
        public void CanGetAllOrderByExtension()
        {
            ////Lazy Loadのデータを取得　拡張属性使って（using EFWComBll;）
            var bll = new OrderBll { DbContext = new NorthWindEntities() };
            var ls = from u in bll.Items.Include(p => p.Customers)
                     select u;

            foreach (var order in ls)
            {
                Debug.WriteLine(order);
            }
        }

    }
}
