using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SalesContext context;

        public CategoryRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Category category)
        {
            try
            {
                if (context.Categoria.Any(c => c.Id == category.Id))
                {
                    throw new CategoryException("La categoría ya se encuentra registrada");
                }

                context.Categoria.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error al crear la categoría", ex);
            }
        }

        public List<Category> GetCategories()
        {
            return context.Categoria
                .Where(c => !c.Eliminado)
                .ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return context.Categoria.Find(categoryId);
        }

        public void Remove(Category category)
        {
            try
            {
                Category categoryRemove = this.GetCategory(category.Id);
                this.context.Categoria.Remove(categoryRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error al eliminar la categoría", ex);
            }
        }

        public void Update(Category category)
        {
            try
            {
                Category categoryToUpdate = context.Categoria.Find(category.Id);

                if (categoryToUpdate == null)
                {
                    throw new CategoryException("La categoría no existe");
                }

               // categoryToUpdate.Nombre = category.Nombre;
                categoryToUpdate.IdUsuarioMod = category.IdUsuarioMod;
                categoryToUpdate.Descripcion = category.Descripcion;
                categoryToUpdate.FechaMod = category.FechaMod;
                categoryToUpdate.EsActivo = category.EsActivo;


                this.context.Categoria.Update(categoryToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CategoryException("Error al actualizar la categoría", ex);
            }
        }
    }
}
