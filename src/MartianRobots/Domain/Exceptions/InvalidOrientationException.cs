using System;
using System.Runtime.Serialization;

namespace Amdiaz.MartianRobots.Domain.Exceptions
{
    [Serializable]
    public class InvalidOrientationException : Exception
    {
        public InvalidOrientationException()
        {
        }

        public InvalidOrientationException(string message) : base(message)
        {
        }

        public InvalidOrientationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidOrientationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}