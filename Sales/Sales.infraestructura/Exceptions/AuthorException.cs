public class AuthorException : Exception
{
    public AuthorException()
        : base("Ocurrió un error relacionado con los autores.")
    {
    }

    public AuthorException(string message)
        : base(message)
    {
    }

    public AuthorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public int? phone { get; set; }

    public string address { get; set; }
}
