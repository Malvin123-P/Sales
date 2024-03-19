namespace Sales.Api.Dtos.Negocio
{
    public class NegocioDeleteDto
    {
        public int Id { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
    }
}
