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
        [Test]
        public void CanUpdate()
        {
            string oriName = "Vins et alcools Chevalier";
            string testName = "for test ShipName";
            var bll = new OrderBll { DbContext = new NorthWindEntities() };
            var orders = from u in bll.Items
                     where u.OrderID == 10248
                     select u;
            Orders order = orders.First();

            Assert.AreEqual(order.ShipName, oriName);
            order.ShipName = testName;
            bll.DbTables.SaveChanges();

            order = (from u in bll.Items
                     where u.OrderID == 10248
                     select u).First();
            Assert.AreEqual(order.ShipName,testName);

            order.ShipName = oriName;
            bll.DbTables.SaveChanges();


        }

        [Test]
        public void CanSearchByEsql()
        {
            var bll = new OrderBll { DbContext = new NorthWindEntities() };
            var esql = "select VALUE c from Orders as c where c.OrderID=10248";
            var qurey= bll.DbTables.CreateQuery<Orders>(esql);
            Debug.WriteLine(qurey.ToTraceString());

            foreach (var orderse in qurey)
            {
                //orderse.CustomersReference.Load(); !!!!場所移動
                Debug.WriteLine(orderse);
            }
        }

    }
}
