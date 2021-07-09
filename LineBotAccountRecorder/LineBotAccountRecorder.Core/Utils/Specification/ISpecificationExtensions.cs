using System;
namespace LineBotAccountRecorder.Core.Utils.Specification
{
    public static class ISpecificationExtensions
    {

        public static ISpecification<TEntity> And<TEntity>(
            this ISpecification<TEntity> left,
            ISpecification<TEntity> right)
            where TEntity : class
        {
            return new And<TEntity>(left, right);
        }

        public static ISpecification<TEntity> Or<TEntity>(
            this ISpecification<TEntity> left,
            ISpecification<TEntity> right)
            where TEntity : class
        {
            return new Or<TEntity>(left, right);
        }

        public static ISpecification<TEntity> Negate<TEntity>(this ISpecification<TEntity> inner)
            where TEntity: class
        {
            return new Negated<TEntity>(inner);
        }
    }
}