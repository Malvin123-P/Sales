namespace Sales.AplicacionCasosDEusos.DtosCasosUsos.Menu
{
    public record MenuDeleteDto
    {
        public int Id { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
    }
}
