using System;
using System.Linq.Expressions;

namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public class And<TEntity> : SpecificationBase<TEntity>
        where TEntity : class
    {

        private readonly ISpecification<TEntity> left;
        private readonly ISpecification<TEntity> right;

        public And(
            ISpecification<TEntity> left,
            ISpecification<TEntity> right)
        {
            this.left = left;
            this.right = right;
        }

        // AndSpecification
        public override Expression<Func<TEntity, bool>> SpecExpression
        {
            get
            {
                var entityParam = Expression.Parameter(typeof(TEntity));

                var newExpr = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.AndAlso(
                        Expression.Invoke(this.left.SpecExpression, entityParam),
                        Expression.Invoke(this.right.SpecExpression, entityParam)),
                    entityParam);

                return newExpr;
            }
        }
    }
}  
