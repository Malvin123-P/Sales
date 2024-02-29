public class CategoryException : Exception
{
    public CategoryException()
        : base("Ocurrió un error relacionado con las categorías.")
    {
    }

    public CategoryException(string message)
        : base(message)
    {
    }

    public CategoryException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public int? CategoryId { get; set; }

    public string CategoryName { get; set; }
}
