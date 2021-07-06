using System;
using System.Linq.Expressions;

namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public abstract class SpecificationBase<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> SpecExpression { get; }

        // return the result of the expression
        // in specifaction pattern, all specification are used to decide yes or no, so it's bool
        public bool IsSatisfiedBy(TEntity entity)
        {
            return this.SpecExpression.Compile().Invoke(entity);
        }
    }
}
