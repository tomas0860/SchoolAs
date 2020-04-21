using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace SchoolAs.DAL.WhereClause
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                        Expression<Func<T, bool>> expr2)
        {
            // create a new expression tree that replace the argument of the second expression with the argument on the first one
            LambdaExpression lambdaExpression = RebuildExpressionIfNeeded(expr1.Parameters[0], expr2);

            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, lambdaExpression.Body), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            // create a new expression tree that replace the argument of the second expression with the argument on the first one
            LambdaExpression lambdaExpression = RebuildExpressionIfNeeded(expr1.Parameters[0], expr2);

            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, lambdaExpression.Body), expr1.Parameters);
        }

        /// <summary>
        /// Rebuilds the expression if we need to change the parameter of the second expression because of different names
        /// </summary>
        /// <param name="p">The parameter of the first expression.</param>
        /// <param name="expr2">The expr2.</param>
        /// <returns></returns>
        private static LambdaExpression RebuildExpressionIfNeeded<T>(ParameterExpression p, Expression<Func<T, bool>> expr2)
        {
            LambdaExpression lambdaExpression;

            if (p.Name != expr2.Parameters[0].Name)
            {
                Expression expression = (new ParameterModifier()).Modify(expr2, p);
                lambdaExpression = ((LambdaExpression)expression);
            }
            else
                lambdaExpression = expr2;
            return lambdaExpression;
        }
    }
}
