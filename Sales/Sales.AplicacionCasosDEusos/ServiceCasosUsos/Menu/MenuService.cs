using Microsoft.Extensions.Logging;
using Sales.AplicacionCasosDEusos.Contracts;
using Sales.AplicacionCasosDEusos.Core;
using Sales.AplicacionCasosDEusos.ModelsCasosUsos.Menu;
using Sales.Infraestructura.Interfaces;
using Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu;


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

        public ServiceResult<List<MenuGetModels>> GetMenu()
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
        public ServiceResult<MenuGetModels> GetMenu(int Id)
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
        public ServiceResult<MenuGetModels> SaveMenu(MenuAddDto menuAddDto)
        {
            ServiceResult<MenuGetModels> result = new ServiceResult<MenuGetModels>();

            try
            {

                if (this.menuRepository.Exists(me=>me.Id == menuAddDto.Id))
                {
                    result.Success = false;
                    result.Message = $"EL MENU { menuAddDto.Id} YA EXISTE.";
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
        public ServiceResult<MenuGetModels> UpdateMenu(MenuUpdateDto menuUpdateDto)
        {
            throw new NotImplementedException();
        }
        public ServiceResult<MenuGetModels> DeleteMenu(MenuDeleteDto menuDeleteDto)
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
    }
}
