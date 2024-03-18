using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas
using Microsoft.EntityFrameworkCore;
using Sales.Dominio.Repository;
using Sales.Infraestructura.Context;



namespace Sales.Infraestructura.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;
        private readonly DbSet<TEntity> Dbentities;
       
        protected BaseRepository(SalesContext context)
        {
            this.context = context;
            this.Dbentities = context.Set<TEntity>();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return Dbentities.Any(filter);
        }

        public virtual List<TEntity> FinndAll(Func<TEntity, bool> filter)
        {
            return Dbentities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            try
            {
                return Dbentities.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public virtual TEntity GetEntity(int Id)
        {
            return Dbentities.Find(Id);
        }

        public virtual void Save(TEntity entity)
        {
           Dbentities.Add(entity);
           context.SaveChanges();
                                    
        }

        public virtual void Update(TEntity entity)
        {
            Dbentities.Update (entity);
            context.SaveChanges();    
        }

        public virtual void Delete(TEntity entity)
        {
            Dbentities.Update(entity);
           this.context.SaveChanges();
        }
    }


}
