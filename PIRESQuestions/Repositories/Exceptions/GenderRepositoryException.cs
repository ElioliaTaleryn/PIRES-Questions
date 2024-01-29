using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    [Serializable]
    internal class GenderRepositoryException : Exception
    {
        public GenderRepositoryException()
        {
        }

        public GenderRepositoryException(string? message) : base(message)
        {
        }

        public GenderRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected GenderRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}