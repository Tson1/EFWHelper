using System;
using System.Collections.Generic;
using System.Data.Objects;

namespace EFWComBll
{
    public interface IEfwComBllBase : IDisposable
    {
        ObjectContext DbContext { get; set; }
        ObjectQuery<T> Find<T>(string esql);
        //void ExcByTran(ObjectContext dbContext, Func<ObjectContext, bool> func);
    }
}