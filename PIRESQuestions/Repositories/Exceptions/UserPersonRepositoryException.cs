using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    [Serializable]
    internal class UserPersonRepositoryException : Exception
    {
        public UserPersonRepositoryException()
        {
        }

        public UserPersonRepositoryException(string? message) : base(message)
        {
        }

        public UserPersonRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserPersonRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}