using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using ModleSale;

namespace SaleBll
{
    public class OrderBll:EFWComBll.EfwComBllBase
    {
        public NorthWindEntities DbTables { get { return (NorthWindEntities)DbContext; } }
        public ObjectQuery<Orders> Items 
        {
            get { return ((NorthWindEntities)DbContext).Orders; }
        } 
    }
}
