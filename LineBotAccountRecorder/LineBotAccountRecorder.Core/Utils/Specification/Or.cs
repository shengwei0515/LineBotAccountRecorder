using System;
using System.Linq.Expressions;

namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public class Or<TEntity> : SpecificationBase<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> left;
        private readonly ISpecification<TEntity> right;

        public Or(
            ISpecification<TEntity> left,
            ISpecification<TEntity> right)
        {
            this.left = left;
            this.right = right;
        }

        public override Expression<Func<TEntity, bool>> SpecExpression
        {
            get
            {
                var entityParam = Expression.Parameter(typeof(TEntity));

                var newExpr = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.OrElse(
                        Expression.Invoke(this.left.SpecExpression, entityParam),
                        Expression.Invoke(this.right.SpecExpression, entityParam)),
                    entityParam);

                return newExpr;
            }
        }
    }
}
