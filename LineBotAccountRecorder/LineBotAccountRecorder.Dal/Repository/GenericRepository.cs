using System;
using System.Linq;
using LineBotAccountRecorder.Core.Utils.Specification;
using LineBotAccountRecorder.Dal.Database;
using Microsoft.EntityFrameworkCore;

namespace LineBotAccountRecorder.Dal.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly AccountRecorderDbContext dbContext = null;

        public GenericRepository(
            AccountRecorderDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Add(entity);
        }

        public TEntity FindOne(ISpecification<TEntity> spec)
        {
            var entity = this.dbContext.Set<TEntity>().Where(spec.SpecExpression).FirstOrDefault();
            return entity;
        }

        public void Update(TEntity entity)
        {
            this.dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            this.dbContext.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }
    }
}
