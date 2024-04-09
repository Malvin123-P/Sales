
using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.Infraestructura.Interfaces;

namespace Sales.AplicacionCasosDEusos.Service.Author
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
            throw new NotImplementedException();
        }

        public ServiceResult<AuthorGetModel> RemoveRol(AuthorRemoveDto authorsRemoveDto)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<AuthorGetModel> SaveAuthor(AuthorDto authorDto)
        {
            ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();

            try
            {
                if (string.IsNullOrEmpty(authorDto.phone))
                {
                    result.Success = false;
                    result.Message = "El autor es requerido";
                    return result;
                }
                if (authorDto.phone.Length > 12)
                {
                    result.Success = false;
                    result.Message = "El telefono debe tener 12 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorDto.address))
                {
                    result.Success = false;
                    result.Message = "El autor es requerido";
                    return result;
                }
                if (authorDto.address.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La direccion debe tener 40 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorDto.state))
                {
                    result.Success = false;
                    result.Message = "El estado es requerido";
                    return result;
                }
                if (authorDto.state.Length > 2)
                {
                    result.Success = false;
                    result.Message = "El estado debe tener 2 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorDto.city))
                {
                    result.Success = false;
                    result.Message = "La ciudad es requerida";
                    return result;
                }
                if (authorDto.state.Length > 2)
                {
                    result.Success = false;
                    result.Message = "La ciudad debe tener 20 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorDto.zip))
                {
                    result.Success = false;
                    result.Message = "El codigo postal es requerida";
                    return result;
                }
                if (authorDto.state.Length > 5)
                {
                    result.Success = false;
                    result.Message = "El codigo postal debe tener 5 caracteres.";
                    return result;
                }
                authorRepository.Save(new Dominio.Entities.Author()
                {
                    state = authorDto.state,
                    city = authorDto.city,
                    zip = authorDto.zip
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el autor";
                logger.LogError(result.Message, ex.ToString());
            }



            return result;
        }

        public ServiceResult<AuthorGetModel> UpdateAuthor(AuthorDtoUpdate authorUpdateDto)
        {
            ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();

            try
            {
                if (string.IsNullOrEmpty(authorUpdateDto.phone))
                {
                    result.Success = false;
                    result.Message = "El autor es requerido";
                    return result;
                }
                if (authorUpdateDto.phone.Length > 12)
                {
                    result.Success = false;
                    result.Message = "El telefono debe tener 12 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorUpdateDto.address))
                {
                    result.Success = false;
                    result.Message = "El autor es requerido";
                    return result;
                }
                if (authorUpdateDto.address.Length > 40)
                {
                    result.Success = false;
                    result.Message = "La direccion debe tener 40 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorUpdateDto.state))
                {
                    result.Success = false;
                    result.Message = "El estado es requerido";
                    return result;
                }
                if (authorUpdateDto.state.Length > 2)
                {
                    result.Success = false;
                    result.Message = "El estado debe tener 2 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorUpdateDto.city))
                {
                    result.Success = false;
                    result.Message = "La ciudad es requerida";
                    return result;
                }
                if (authorUpdateDto.state.Length > 2)
                {
                    result.Success = false;
                    result.Message = "La ciudad debe tener 20 caracteres.";
                    return result;
                }
                if (string.IsNullOrEmpty(authorUpdateDto.zip))
                {
                    result.Success = false;
                    result.Message = "El codigo postal es requerida";
                    return result;
                }
                if (authorUpdateDto.state.Length > 5)
                {
                    result.Success = false;
                    result.Message = "El codigo postal debe tener 5 caracteres.";
                    return result;
                }
                authorRepository.Save(new Dominio.Entities.Author()
                {
                    state = authorUpdateDto.state,
                    city = authorUpdateDto.city,
                    zip = authorUpdateDto.zip
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el autor";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<AuthorGetModel> UpdateRol(AuthorDtoUpdate authorsUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
    }

