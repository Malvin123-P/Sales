using Sales.Dominio.Repository;
using Sales.Infraestructura.Context;

namespace Sales.Infraestructura.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;

        protected BaseRepository(SalesContext context)
        {
            this.context = context;
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
