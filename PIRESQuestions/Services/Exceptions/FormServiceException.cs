using System.Runtime.Serialization;

namespace Services.Exceptions
{
    [Serializable]
    internal class FormServiceException : Exception
    {
        public FormServiceException() 
        { 
        }

        public FormServiceException(string? message) : base(message)
        {
        }

        public FormServiceException(string? message, Exception? innerException) : base(message, innerException) 
        {
        }

        protected FormServiceException(SerializationInfo info, StreamingContext context) : base(info, context) 
        {
        }
    }
}
