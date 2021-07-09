using System;
using LineBotAccountRecorder.Core.Utils.Specification;

namespace LineBotAccountRecorder.Dal.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Create(TEntity entity);

        TEntity FindOne(ISpecification<TEntity> spec);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}