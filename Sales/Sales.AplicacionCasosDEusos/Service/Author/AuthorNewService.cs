using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Models.Author;
using Sales.Dominio.Entities;
using Sales.Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sales.Application.Service.Author
{
    public class AuthorNewService : IAuthorService
    {
        private readonly ILogger<AuthorNewService> logger;
        private readonly IAuthorRepository authorRepository;

        public AuthorNewService(ILogger<AuthorNewService> logger,
                               IAuthorRepository authorRepository)
        {
            this.logger = logger;
            this.authorRepository = authorRepository;
        }

        public ServicesResult<AuthorGetModel> Get(int Id)
        {
            ServicesResult<AuthorGetModel> result = new ServicesResult<AuthorGetModel>();

            try
            {
                var author = this.authorRepository.GetEntity(Id);

                if (author != null)
                {
                    result.Data = new AuthorGetModel
                    {
                        phone = author.phone,
                        address = author.address,
                        city = author.city,
                        state = author.state,
                        zip = author.zip,
                    };
                }
                else
                {
                    result.Success = false;
                    result.Message = "El autor no existe.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el autor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;

        }

        public ServicesResult<List<AuthorGetModel>> GetAll()
        {
            ServicesResult<List<AuthorGetModel>> result = new ServicesResult<List<AuthorGetModel>>();

            try
            {
                var authors = this.authorRepository.GetEntities().Select(
                    author => new AuthorGetModel()
                    {
                        phone = author.phone,
                        address = author.address,
                        city = author.city,
                        state = author.state,
                        zip = author.zip,
                    }).ToList();

                result.Data = authors;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los autores.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<AuthorGetModel> Remove(AuthorRemoveDto RemoveDto)
        {
            ServicesResult<AuthorGetModel> result = new ServicesResult<AuthorGetModel>();

            try
            {
                this.authorRepository.Remove(new Author()
                {
                    id = RemoveDto.phone,
                    IdUsuarioElimino = RemoveDto.UserId,
                    FechaElimino = RemoveDto.ChangeDate
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el autor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<AuthorGetModel> Save(AuthorDtoAdd AddDto)
        {
            ServicesResult<AuthorGetModel> result = new ServicesResult<AuthorGetModel>();

            try
            {
                var validationResult = this.IsValid(AddDto, DtoAction.Save);

                if (!validationResult.Success)
                {
                    result.Message = validationResult.Message;
                    result.Success = validationResult.Success;
                    return result;
                }

                this.authorRepository.Save(new Author()
                {
                    phone = AddDto.phone,
                    address = AddDto.address,
                    city = AddDto.city,
                    state = AddDto.state,
                    zip = AddDto.zip,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el autor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServicesResult<AuthorGetModel> Update(AuthorDtoUpdate UpdateDto)
        {
            ServicesResult<AuthorGetModel> result = new ServicesResult<AuthorGetModel>();

            try
            {
                var validationResult = this.IsValid(UpdateDto, DtoAction.Update);

                if (!validationResult.Success)
                {
                    result.Success = result.Success;
                    result.Message = validationResult.Message;
                    return result;
                }

                var author = this.authorRepository.GetEntity(UpdateDto.phone);

                if (author == null)
                {
                    result.Success = false;
                    result.Message = "El autor no existe.";
                    return result;
                }

                author.phone = UpdateDto.phone;
                author.address = UpdateDto.address;
                author.city = UpdateDto.city;
                author.state = UpdateDto.state;
                author.zip = UpdateDto.zip;

                this.authorRepository.Update(author);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el autor.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServicesResult<string> IsValid(AuthorDtoBase authorDtoBase, DtoAction action)
        {
            ServicesResult<string> result = new ServicesResult<string>();

            if (string.IsNullOrEmpty(authorDtoBase.phone))
            {
                result.Success = false;
                result.Message = "El nombre del autor es requerido.";
                return result;
            }

            if (authorDtoBase.address.Length > 15)
            {
                result.Success = false;
                result.Message = "El nombre de la categoría debe tener máximo 15 caracteres.";
                return result;
            }

            if (string.IsNullOrEmpty(authorDtoBase.city))
            {
                result.Success = false;
                result.Message = "La descripción de la categoría es requerida.";
                return result;
            }

            if (authorDtoBase.state.Length > 200)
            {
                result.Success = false;
                result.Message = "La descripción de la categoría debe tener máximo 200 caracteres.";
                return result;
            }

            if (this.authorRepository.Exists(ca => ca.zip == authorDtoBase.zip))
            {
                result.Success = false;
                result.Message = $"El autor {authorDtoBase.Name} ya existe.";
                return result;
            }

            return result;
        }
    }
}


