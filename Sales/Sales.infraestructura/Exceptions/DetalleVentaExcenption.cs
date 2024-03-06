using System.Runtime.Serialization;

namespace Sales.Infraestructura.Exceptions
{
    [Serializable]
    internal class DetalleVentaExcenption : Exception
    {
        public DetalleVentaExcenption()
        {
        }

        public DetalleVentaExcenption(string? message) : base(message)
        {
        }

        public DetalleVentaExcenption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DetalleVentaExcenption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}