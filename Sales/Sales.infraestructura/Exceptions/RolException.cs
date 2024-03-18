public class RolException : Exception
{
    public RolException()
        : base("Ocurrió un error relacionado con los Roles.")
    {
    }

    public RolException(string message)
        : base(message)
    {
    }

    public RolException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public string nombre;

    public string? Descripcion { get; set; }
    public bool? EsActivo { get; set; }
    public string? IdUsuario { get; set; }
    public string? FechaEliminar { get; set; }
}
