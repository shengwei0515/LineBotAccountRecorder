using System;
using System.Linq.Expressions;

namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public class Negated<TEntity> : SpecificationBase<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> inner;

        public Negated(
            ISpecification<TEntity> inner)
        {
            this.inner = inner;
        }

        public override Expression<Func<TEntity, bool>> SpecExpression
        {
            get
            {
                var entityParam = Expression.Parameter(typeof(TEntity));

                var newExpr = Expression.Lambda<Func<TEntity, bool>>(
                    Expression.Not(
                        Expression.Invoke(this.inner.SpecExpression, entityParam)
                        ), entityParam
                    );

                return newExpr;
            }
        }
    }
}
