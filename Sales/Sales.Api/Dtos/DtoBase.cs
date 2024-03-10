namespace Sales.Api.Dtos
{
    public class DtoBase
    {
        public int Id { get; set; }

        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaMod { get; set; }

        public int IdUsuarioCreacion { get; set; }

        public int? IdUsuarioMod { get; set; }

        public int? IdUsuarioElimino { get; set; }

        public DateTime? FechaElimino { get; set; }

        public bool Eliminado { get; set; }

    }
}
