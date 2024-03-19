
using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.AplicacionCasosDEusos.Models.Configuracion;
using Sales.Infraestructura.Interfaces;

namespace Sales.AplicacionCasosDEusos.Service
{
    internal class AuthorService : IAuthorService
    {
        private readonly ILogger<AuthorService> logger;
        private readonly IAuthorsRepository authorRepository;
        public AuthorService(ILogger<AuthorService> logger,
                                    IAuthorsRepository authorRepository)
        {
            this.logger = logger;
            this.authorRepository = authorRepository;
        }
        public ServiceResult<AuthorGetModel> GetAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<List<AuthorGetModel>> GetAuthors()
        {
            ServiceResult<List<AuthorGetModel>> result = new ServiceResult<List<AuthorGetModel>>();
            try
            {
                result.Data = this.authorRepository.GetEntities().Select(cd => new AuthorGetModel() 
                {
                    phone = cd.phone,
                    address = cd.address,
                    city = cd.city,
                    state = cd.state,
                    zip = cd.zip,

                }).ToList();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo los autores";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<AuthorGetModel> RemoveRol(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<AuthorGetModel> SaveAuthor(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<AuthorGetModel> UpdateRol(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }
    }
}
