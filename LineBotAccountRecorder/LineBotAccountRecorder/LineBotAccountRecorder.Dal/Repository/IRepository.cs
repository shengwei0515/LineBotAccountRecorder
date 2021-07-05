using System;
//using LineBotAccountRecorder.Core.Utils.Specification;
namespace LineBotAccountRecorder.Dal.Repository
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);

        //TEntity FindOne(ISpecification<TEntity> spec);


    }
}
