using System;
using LineBotAccountRecorder.Dal.Repository;

namespace LineBotAccountRecorder.Dal.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
