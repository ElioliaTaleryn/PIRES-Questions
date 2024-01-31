using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    [Serializable]
    public class AnonymousRepositoryException : Exception
    {
        public AnonymousRepositoryException()
        {
        }

        public AnonymousRepositoryException(string? message) : base(message)
        {
        }

        public AnonymousRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AnonymousRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}