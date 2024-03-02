using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infraestructura.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository where TEntity : class
    {

        private readonly SalesContext context;
        private readonly DbSet<TEntity> DbEntity;

        protected BaseRepository(SalesContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any(filter);
        }

        public virtual List<TEntity> FinAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntity.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return DbEntity.Find(id);
        }

        public void Remove(TEntity entity)
        {
            DbEntity.Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            DbEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }

        public bool Exists(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }


        public List<TEntity> FinAll(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}
