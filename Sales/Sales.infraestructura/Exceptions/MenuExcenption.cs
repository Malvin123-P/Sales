using System.Runtime.Serialization;

namespace Sales.Infraestructura.Exceptions
{
    [Serializable]
    internal class MenuExcenption : Exception
    {
        public MenuExcenption()
        {
        }

        public MenuExcenption(string? message) : base(message)
        {
        }

        public MenuExcenption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MenuExcenption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}