using System.Runtime.Serialization;

namespace Repositories.Exceptions
{
    [Serializable]
    public class FormRepositoryException : Exception
    {
        public FormRepositoryException()
        { 
        }

        public FormRepositoryException(string? message) : base(message)
        {
        }

        public FormRepositoryException(string? message, Exception? innerException) : base(message, innerException) 
        { 
        }

        protected FormRepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}
