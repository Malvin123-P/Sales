public class RolMenuException : Exception
{
    public RolMenuException()
        : base("Ocurrió un error relacionado con Rol Menu establecido.")
    {
    }

    public RolMenuException(string message)
        : base(message)
    {
    }

    public RolMenuException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public int? IdRolMenu { get; set; }

    public string NombreRolMenu { get; set; }
}