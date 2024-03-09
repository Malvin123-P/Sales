using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class CategoryRepository : BaseRepository<Categoria>, ICategoryRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<CategoryRepository> logger;

        public CategoryRepository(SalesContext context, ILogger<CategoryRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Categoria> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Categoria entity)
        {
            try
            {
                var categoryToUpdate = this.GetEntity(entity.id);

                if (categoryToUpdate == null)
                {
                    throw new CategoryException("La categoría no existe");
                }

                categoryToUpdate.nombre = entity.nombre;
                categoryToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                categoryToUpdate.Descripcion = entity.Descripcion;
                categoryToUpdate.FechaMod = entity.FechaMod;
                categoryToUpdate.EsActivo = entity.EsActivo;


                this.context.Categories.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar la categoría", ex.ToString());
            }
        }

        public override void Save(Categoria entity)
        {
            try
            {
                if (context.Categories.Any(c => c.id == entity.id))
                {
                    this.logger.LogWarning("La categoría ya se encuentra registrada");
                }

                context.Categories.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar la categoría", ex.ToString());
            }
        }

        public override Categoria GetEntity(int id)
        {
            return this.context.Categories.Find(id);
        }

        public override bool Exists(Func<Categoria, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Categoria> FinAll(Func<Categoria, bool> filter)
        {
            return base.FinAll(filter);
        }

        
    }
    
}
