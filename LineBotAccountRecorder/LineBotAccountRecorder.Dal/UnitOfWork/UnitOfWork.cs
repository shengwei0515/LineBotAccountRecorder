using System;
using System.Collections;
using LineBotAccountRecorder.Dal.Database;
using LineBotAccountRecorder.Dal.Repository;

namespace LineBotAccountRecorder.Dal.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountRecorderDbContext dbContext = null;
        private Hashtable repositories = null;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">AnimalAdoptionDbContext</param>
        public UnitOfWork(
            AccountRecorderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Get repository of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Repository</returns>
        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!this.repositories.ContainsKey(type))
            {
                var repositoryInstance =
                    Activator.CreateInstance(typeof(GenericRepository<TEntity>), this.dbContext);

                this.repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>)this.repositories[type];
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.dbContext.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
