public class NumeroCorrelativoException : Exception
{
    public NumeroCorrelativoException()
        : base("Ocurrió un error relacionado con el Numero Correlativo.")
    {
    }

    public NumeroCorrelativoException(string message)
        : base(message)
    {
    }

    public NumeroCorrelativoException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public int? IdNumeroCorrelativo { get; set; }

    public string ElNumeroCorrelativo { get; set; }
}