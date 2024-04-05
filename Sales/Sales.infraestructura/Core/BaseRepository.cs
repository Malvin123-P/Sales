using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Repository;
using Sales.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sales.Infraestructura.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;
        private readonly DbSet<TEntity> DbEntity;

        protected BaseRepository(SalesContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }

        public static object GetEntity(Sales.AplicacionCasosDEusos.Service.Author author)
        {
            throw new NotImplementedException();
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
    }
}
