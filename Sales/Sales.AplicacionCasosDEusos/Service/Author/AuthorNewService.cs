using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contract.Author;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.Dtos.Author;
using Sales.AplicacionCasosDEusos.Dtos.Configuracion;
using Sales.AplicacionCasosDEusos.Dtos.Enums;
using Sales.AplicacionCasosDEusos.Dtos.Rol;
using Sales.AplicacionCasosDEusos.Models.Author;
using System;
using System.Runtime.CompilerServices;

namespace Sales.AplicacionCasosDEusos.Service.Author
{
    internal class ConfiguracionNewService : IAuthorNewService
    {
        public ServiceResult<AuthorGetModel> Get(int authorId)
        {

            {
                ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();
                try
                {
                    var author = authorRepository.GetEntity(authorId);

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
                    logger.LogError(result.Message, ex.ToString());
                }
            }
        }

        public ServiceResult<List<AuthorGetModel>> GetAll()
        {
            ServiceResult<List<AuthorGetModel>> result = new ServiceResult<List<AuthorGetModel>>();
            try
            {
                result.Data = authorRepository.GetEntities().Select(cd => new AuthorGetModel()
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
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }

        public ServiceResult<AuthorGetModel> Remove(AuthorsRemoveDto authorsRemoveDto)
        {
        ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();

        try
        {
            this.authorRepository.Remove(new Author()
            {
                phone = authorRemoveDto.phone,
                state = authorRemoveDto.state,
                city = authorRemoveDto.city,
                zip = authorRemoveDto.zip
            });
        }
        catch (Exception ex)
        {

            result.Success = false;
            result.Message = "Error obteniendo el autor";
            this.logger.LogError(result.Message, ex.ToString());
        }
    }

        public ServiceResult<AuthorGetModel> Save(AuthorDto authorDto)
        {
        ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();
        try
        {

            var resultIsValid = this.IsValid(authorDto, DtoAction.Update);
            if (!resultIsValid.Success)
            {
                result.Message = resultIsValid.Message;
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
            logger.LogError(result.Message, ex.ToString());
        }

        return result;
    }
}

        public class ServiceResult<AuthorGetModel> Update(AuthorsUpdateDto authorsUpdateDto)
        
        ServiceResult<AuthorGetModel> result = new ServiceResult<AuthorGetModel>();
   
        try
        {
        var resultIsValid = this.Isvalid(authorUpdateDto, DtoAction.Save);

    if (!resultIsValid.Success)
    {
        result.Message = resultIsValid.Message;
    }
    this.authorRepository.Save(new Dominio.Entities.Authors()
            {
                phone = authorsUpdateDto.phone,
                state = authorsUpdateDto.state,
                city = authorsUpdateDto.city,
                zip = authorsUpdateDto.zip
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
            }
        

      private ServiceResult<string> IsValid(AuthorsDtoBase authorsDtoBase, DtoAction action)
    {
      ServiceResult<string> result = new ServiceResult<string>();

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
}
if (action == DtoAction.Save)
{
    if (this.authorRepository.Exists(ca => ca.authorname == authorDtoBase.phone))
    {
        result.Success = false;
        result.Message = $"El autor {authorDtoBase.Phone} ya existe.";
    }
    return result;

}
