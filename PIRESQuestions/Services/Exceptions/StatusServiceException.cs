using System.Runtime.Serialization;

namespace Services.Exceptions
{
    [Serializable]
    internal class StatusServiceException : Exception
    {
        public StatusServiceException()
        {
        }

        public StatusServiceException(string? message) : base(message)
        {
        }

        public StatusServiceException(string? message, Exception? innerException) : base(message, innerException) 
        {
        }

        protected StatusServiceException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}
