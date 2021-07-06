using System;
using System.Linq.Expressions;

namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> SpecExpression { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
