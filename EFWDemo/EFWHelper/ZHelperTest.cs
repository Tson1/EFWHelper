using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NUnit.Framework;
namespace EFWHelper
{
    [TestFixture]
    public class ZHelperTest
    {
        [Test]
        public void CanGetProName()
        {
            var ex=new Expre<MyClass>();
            //ex.And.Add(ex.Ps.FirstName, "my", Match.Eq);

            string n= Utility.GetPropertyName<MyClass>(c => c.FirstName);
            Debug.WriteLine(n);

            Debug.WriteLine(ex.GetName(c => c.FirstName));
            Debug.WriteLine(Utility.GetPropertyName<MyClass>(c => c.Age));
            Debug.WriteLine(ex.GetName(c => c.Age));
            Debug.WriteLine(ex.GetName(c => c.BerthDay));
        }

        [Test]
        public void CanGetExpression()
        {
            var ex = new Expre<MyClass>();
            ex.And.Add(ex.GetName(c => c.FirstName), "Tson1", Match.Eq);
            ex.Or.Add(ex.GetName(c => c.Age), 30, Match.Gt);
            Debug.WriteLine(ex.GetSQL());
        }


    }

    class MyClass
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
        public DateTime BerthDay { get; set; }
    }
}
