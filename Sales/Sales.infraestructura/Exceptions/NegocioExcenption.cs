using System.Runtime.Serialization;

namespace Sales.Infraestructura.Exceptions
{
    [Serializable]
    internal class NegocioExcenption : Exception
    {
        public NegocioExcenption()
        {
        }

        public NegocioExcenption(string? message) : base(message)
        {
        }

        public NegocioExcenption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NegocioExcenption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}