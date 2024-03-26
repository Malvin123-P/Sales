namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.Negocio
{
    public record NegocioDeleteDto
    {
        public int Id { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
    }
}
