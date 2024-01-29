using System.Runtime.Serialization;

namespace Services.Exceptions
{
    [Serializable]
    internal class GenderServiceException : Exception
    {
        public GenderServiceException()
        {
        }

        public GenderServiceException(string? message) : base(message)
        {
        }

        public GenderServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GenderServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}