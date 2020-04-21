using System.Linq.Expressions;

namespace SchoolAs.DAL.WhereClause
{
    internal class ParameterModifier : ExpressionVisitor
    {
        public Expression Modify(Expression expression, ParameterExpression newParam)
        {
            _newParam = newParam;
            return Visit(expression);
        }

        private ParameterExpression _newParam;

        protected override Expression VisitParameter(ParameterExpression p)
        {
            return _newParam;
        }
    }
}
