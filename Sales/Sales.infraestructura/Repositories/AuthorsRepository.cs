using Microsoft.Extensions.Logging;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Context;
using Sales.Infraestructura.Core;
using Sales.Infraestructura.Interfaces;

namespace Sales.Infraestructura.Repositories
{
    public class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<AuthorsRepository> logger;

        public AuthorsRepository(SalesContext context, ILogger<AuthorsRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Author> GetEntities()
        {
            return this.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Author entity)
        {
            try
            {
                var authorsToUpdate = this.GetEntity(entity.id);

                if (authorsToUpdate == null)
                {
                    throw new CategoryException("El autor no existe");
                }

                authorsToUpdate.nombre = entity.nombre;
                authorsToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                authorsToUpdate.state = entity.state;
                authorsToUpdate.FechaMod = entity.FechaMod;
                authorsToUpdate.city = entity.city;


                this.context.Authors.Update(authorsToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al actualizar el author", ex.ToString());
            }
        }

        public override void Save(Author entity)
        {
            try
            {
                if (context.Rol.Any(c => c.id == entity.id))
                {
                    this.logger.LogWarning("El autor ya se encuentra registrado");
                }

                context.Authors.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error al registrar el autor", ex.ToString());
            }
        }

        public override Author GetEntity(int id)
        {
            return this.context.Authors.Find(id);
        }

        public override bool Exists(Func<Author, bool> filter)
        {
            return base.Exists(filter);
        }

        public override List<Author> FinAll(Func<Author, bool> filter)
        {
            return base.FinAll(filter);
        }

        public void Remove(Author entity)
        {
            try
            {
                Author authorToRemove = this.GetEntity(entity.phone);

                if (authorToRemove is null)
                    throw new AuthorException("El autor no existe.");

                authorToRemove.phone = entity.phone;
                authorToRemove.address = entity.address;
                authorToRemove.state = entity.state;
                authorToRemove.zip = entity.zip;
                authorToRemove.city = entity.city;

                this.context.Authors.Update(authorToRemove);
                this.context.SaveChanges();

            }
            catch (Exception ex)
            {

                this.logger.LogError("", ex.ToString());
            };

        }
    }

}
