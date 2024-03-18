public class ProductoException : Exception
{
    public ProductoException()
        : base("Ocurrió un error relacionado con los productos.")
    {
    }

    public ProductoException(string message)
        : base(message)
    {
    }

    public ProductoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public int? ProductoId { get; set; }

    public string CodigoProducto { get; set; }

    public string DescripcionProducto { get; set; }
}
