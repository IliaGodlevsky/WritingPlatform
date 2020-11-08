using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WritingPlatform.Base.Abstractions;

namespace WritingPlatform.Data
{
    internal abstract class Repository<TEntity> : IRepository<TEntity>
         where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> dbSet;

        private readonly DbContext context;

        protected Repository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
            
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.AddOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}
