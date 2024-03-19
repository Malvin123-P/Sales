﻿
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
            ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();
            try
            {
                var author = this.authorRepository.GetEntity(authorId);

                result.Data = new AuthorGetModel()
                {
                    phone = author.phone,
                    address = author.address,
                    city = author.city,
                    state = author.state,
                    zip = author.zip,
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo el autor";
                this.logger.LogError(result.Message, ex.ToString());
            }
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
                this.authorRepository.Save(new Dominio.Entities.Authors()
                {
                    phone = authorDto.phone,
                    state = authorDto.state,
                    city = authorDto.city,
                    zip = authorDto.zip
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error guardando el autor";
                this.logger.LogError(result.Message, ex.ToString());
            }



            return result;
        }

        public ServiceResult<AuthorGetModel> UpdateRol(AuthorDto authorDto)
        {
            throw new NotImplementedException();
        }
    }
}
