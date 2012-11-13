using System;
using System.Linq.Expressions;

namespace EFWHelper
{
    public static class Utility
    {
        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            //take care Conver
            if (expression.Body is UnaryExpression)
            {
                var unex = (UnaryExpression)expression.Body;
                if (unex.NodeType == ExpressionType.Convert)
                {
                    Expression ex = unex.Operand;
                    var mex = (MemberExpression)ex;
                    return mex.Member.Name;
                }
            }


            var memberExpr = expression.Body as MemberExpression;
            if (memberExpr == null)
                throw new ArgumentException("Expression body must be a member expression");
            return memberExpr.Member.Name;
        }
    }
}
