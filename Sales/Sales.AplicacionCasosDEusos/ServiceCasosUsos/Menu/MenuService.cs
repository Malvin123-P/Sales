using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;
using Sales.Infraestructura.Interfaces;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Emun;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio;


namespace Sales.AplicacionCasosDEusos.ServiceCasosUsos.Menu
{
    public class MenuService : IMenuService
    {
        private readonly ILogger<MenuService> logger;
        private readonly IMenuRepository menuRepository;

        public MenuService(ILogger<MenuService> logger, IMenuRepository menuRepository)
        {
            this.logger = logger;
            this.menuRepository = menuRepository;
        }

        public ServiceResult<List<MenuGetModels>> GetAll()
        {
            ServiceResult<List<MenuGetModels>> result = new ServiceResult<List<MenuGetModels>>();
          
            try
            {
                result.Data = this.menuRepository.GetEntities().Select(me => new MenuGetModels() 
                {
                    Id = me.Id,
                    Descripcion = me.Descripcion,
                    IdMenuPadre = me.IdMenuPadre,
                    Icono = me.Icono,
                    PaginaAccion = me.PaginaAccion,
                    EsActivo = me.EsActivo,
                    Controlador = me.Controlador,
                    FechaRegistro = me.FechaRegistro,
                    IdUsuarioCreacion = me.IdUsuarioCreacion
                }).ToList();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "ERROR OBTENIENDO EL MENU";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }
        public ServiceResult<MenuGetModels> Get(int Id)
        {
            ServiceResult<MenuGetModels> result = new ServiceResult<MenuGetModels>();

            try
            {
                var menu = this.menuRepository.GetEntity(Id);


                result.Data = new MenuGetModels()
                {
                    Id = menu.Id,
                    Descripcion = menu.Descripcion,
                    EsActivo = menu.EsActivo,
                    IdMenuPadre = menu.IdMenuPadre,
                    Icono = menu.Icono,
                    Controlador = menu.Controlador,
                    PaginaAccion = menu.PaginaAccion,
                    FechaRegistro = menu.FechaRegistro,
                    IdUsuarioCreacion = menu.IdUsuarioCreacion
                };
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR OBTENIENDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }
        public ServiceResult<MenuGetModels> Save(MenuAddDto menuAddDto)
        {
            ServiceResult<MenuGetModels> result = new ServiceResult<MenuGetModels>();

            try
            {

                var resultIsVali = this.IsValid(menuAddDto, DtoAction.Save);

                if (!resultIsVali.Success)
                {
                    result.Message = resultIsVali.Message;
                    return result;
                }

                this.menuRepository.Save(new Dominio.Entities.Menu()
                {
                    Descripcion = menuAddDto.Descripcion,
                    IdMenuPadre = menuAddDto.IdMenuPadre,
                    Icono = menuAddDto.Icono,
                    PaginaAccion = menuAddDto.PaginaAccion,
                    EsActivo = menuAddDto.EsActivo,
                    Controlador = menuAddDto.Controlador,
                    FechaRegistro = menuAddDto.FechaRegistro,
                    IdUsuarioCreacion = menuAddDto.IdUsuarioCreacion,
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR GUARDANDO EL MENU";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }
        public ServiceResult<MenuGetModels> Update(MenuUpdateDto menuUpdateDto)
        {
            ServiceResult<MenuGetModels> result = new ServiceResult<MenuGetModels>();

            try
            {

                var resultIsVali = this.IsValid(menuUpdateDto, DtoAction.Update);

                if (!resultIsVali.Success)
                {
                    result.Message = resultIsVali.Message;
                    return result;
                }

                this.menuRepository.Update(new Dominio.Entities.Menu()
                {
                    Descripcion = menuUpdateDto.Descripcion,
                    IdMenuPadre = menuUpdateDto.IdMenuPadre,
                    Icono = menuUpdateDto.Icono,
                    PaginaAccion = menuUpdateDto.PaginaAccion,
                    EsActivo = menuUpdateDto.EsActivo,
                    Controlador = menuUpdateDto.Controlador,
                    FechaMod = menuUpdateDto.FechaMod,
                    IdUsuarioMod = menuUpdateDto.IdUsuarioMod,
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "EERROR GUARDANDO EL NEGOCIO";
                this.logger.LogError(result.Message, ex.ToString);
            }

            return result;
        }
        public ServiceResult<MenuGetModels> Delete(MenuDeleteDto menuDeleteDto)
        {
            ServiceResult<MenuGetModels> result = new ServiceResult<MenuGetModels>();

            try
            {
                this.menuRepository.Delete(new Dominio.Entities.Menu()
                {
                    Id = menuDeleteDto.Id,
                    FechaElimino = menuDeleteDto.FechaElimino,
                    IdUsuarioElimino = menuDeleteDto.IdUsuarioElimino
                });

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "ERROR BORRANDO EL MENU";
                this.logger.LogError(result.Message, ex.ToString);
            }
            return result;
        }

        public ServiceResult<string> IsValid(MenuBaseDto menuBaseDto, DtoAction dtoAction)
        {
            ServiceResult<string> result = new ServiceResult<string>();

            //Validaciones

            if (dtoAction == DtoAction.Save)
            {
                if (this.menuRepository.Exists(ne => ne.Id == menuBaseDto.Id))
                {
                    result.Success = false;
                    result.Message = $"EL MENU {menuBaseDto.Id} YA EXISTE.";
                    return result;
                }
            }
            return result;
        }
    }
}
