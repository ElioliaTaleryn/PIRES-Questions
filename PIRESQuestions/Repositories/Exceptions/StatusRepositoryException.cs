using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    public class StatusRepositoryException : Exception
    {
        public StatusRepositoryException()
        {
        }

        public StatusRepositoryException(string? message) : base(message)
        {
        }

        public StatusRepositoryException(string? message, Exception innerException) : base(message, innerException)
        {
        }

        protected StatusRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}
