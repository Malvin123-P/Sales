using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class ProductRepository : IProductoRepository
    {
        private readonly SalesContext context;

        public ProductRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Producto producto)
        {
            try
            {
                // Check for existing product id (optional)
                 if (context.Products.Any(p => p.Id == producto.Id))
                 {
                      throw new ProductoException("Ya existe un producto con el id ingresado.");
                 }

                this.context.Products.Add(producto);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ProductoException("Error al crear el producto", ex);
            }
        }

        public Producto GetProducto(int productId)
        {
            return this.context.Products.Find(productId);
        }

        public List<Producto> GetProductos()
        {
            return this.context.Products.ToList();
        }

        public void Remove(Producto producto)
        {
            try
            {
                Producto productToRemove = this.GetProducto(producto.Id);

                if (productToRemove == null)
                {
                    throw new ProductoException("El producto no existe");
                }

                this.context.Products.Remove(productToRemove);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ProductoException("Error al eliminar el producto", ex);
            }
        }

        public void Update(Producto producto)
        {
            try
            {
                Producto productToUpdate = this.GetProducto(producto.Id);

                if (productToUpdate == null)
                {
                    throw new ProductoException("El producto no existe");
                }

                productToUpdate.Descripcion = producto.Descripcion;
                productToUpdate.FechaMod = producto.FechaMod;
                productToUpdate.IdCategoria = producto.IdCategoria;
                productToUpdate.Precio = producto.Precio;
                productToUpdate.Stock = producto.Stock;
                productToUpdate.Marca = producto.Marca;
                productToUpdate.IdUsuarioMod = producto.IdUsuarioMod;

                this.context.Products.Update(productToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ProductoException("Error al actualizar el producto", ex);
            }
        }
    }
}
