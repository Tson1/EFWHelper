using System;
using System.Data.Objects;

namespace EFWComBll
{
    public class EfwComBllBase : IEfwComBllBase
    {
        public static void ExcByTran(ObjectContext dbContext, Func<ObjectContext, bool> func)
        {
            var edm = dbContext;
            System.Data.Common.DbTransaction tran = null;
            try
            {
                edm.Connection.Open();
                tran = edm.Connection.BeginTransaction();
                func(dbContext);
                edm.SaveChanges();
                tran.Commit();
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                throw new Exception("RollBack ", ex);
            }

            finally
            {
                if (edm != null && edm.Connection.State != System.Data.ConnectionState.Closed)
                    edm.Connection.Close();
            }
        }

        #region IEfwComBllBase メンバ

        public ObjectContext DbContext { get; set; }

        #endregion

        #region IDisposable メンバ

        public void Dispose()
        {
            if (null!=DbContext)
            {
                DbContext.Dispose();
            }
        }

        #endregion

        #region IEfwComBllBase メンバ
        public ObjectQuery<T> Find<T>(string esql)
        {
            var query = DbContext.CreateQuery<T>(esql);
            //query.ToTraceString(); //SQL 表示
            return query;
        }


        #endregion
    }
}
