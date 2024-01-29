using System.Runtime.Serialization;

namespace Services
{
    [Serializable]
    internal class UserPersonServiceException : Exception
    {
        public UserPersonServiceException()
        {
        }

        public UserPersonServiceException(string? message) : base(message)
        {
        }

        public UserPersonServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserPersonServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}