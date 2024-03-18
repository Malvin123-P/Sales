using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Dominio.Repository
{
        public interface IBaseRepository<TEntity> where TEntity : class
        {
          TEntity GetEntity(int Id);
          List<TEntity> GetEntities();
          List<TEntity> FinndAll(Func<TEntity, bool> filter);
          bool Exists (Func<TEntity, bool> filter);
          void Save(TEntity entity);
          void Update(TEntity entity);
          void Delete(TEntity entity);       
        }
    
}
