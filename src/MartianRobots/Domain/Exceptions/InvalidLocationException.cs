using System;
using System.Runtime.Serialization;

namespace Amdiaz.MartianRobots.Domain.Exceptions
{
    [Serializable]
    public class InvalidLocationException : Exception
    {
        public InvalidLocationException()
        {
        }

        public InvalidLocationException(string message) : base(message)
        {
        }

        public InvalidLocationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidLocationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}