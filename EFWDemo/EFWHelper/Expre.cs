using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFWHelper
{
    public class Expre<TEntity> where TEntity : class, new()
    {
        
        private readonly Condisions _and = new Condisions();
        private readonly Condisions _or =new Condisions();
        private readonly Condisions _orderBy=new Condisions();
        public Condisions And { get { return _and; } }
        public Condisions Or { get { return _or; } }
        public Condisions OrderBy { get { return _orderBy; } }
        public string GetName(Expression<Func<TEntity, object>> expression)
        {
            return Utility.GetPropertyName<TEntity>(expression);
        }
        public string GetSQL()
        {
            const string C = "c";
            var tblName = typeof (TEntity).Name;
            var sb=new StringBuilder();
            sb.Append("SELECT VALUE c FROM");
            sb.Append(tblName).AppendLine(" as c");
            sb.AppendLine(" WHERE ");
            sb.AppendLine(And.GetAndEsql());

            var OrSql = Or.GetOrEsql();
            sb.Append(string.IsNullOrEmpty(OrSql) ? string.Empty : " OR ");
            sb.AppendLine(OrSql);

            return sb.ToString();
        }


    }
}
