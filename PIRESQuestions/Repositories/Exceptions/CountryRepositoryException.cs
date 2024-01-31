using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    [Serializable]
    internal class CountryRepositoryException : Exception
    {
        public CountryRepositoryException()
        {
        }

        public CountryRepositoryException(string? message) : base(message)
        {
        }

        public CountryRepositoryException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CountryRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}