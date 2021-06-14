using System;
using System.Runtime.Serialization;

namespace Amdiaz.MartianRobots.Domain.Exceptions
{
    [Serializable]
    public class InvalidTerrainCoordinates : Exception
    {
        public InvalidTerrainCoordinates()
        {
        }

        public InvalidTerrainCoordinates(string message) : base(message)
        {
        }

        public InvalidTerrainCoordinates(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTerrainCoordinates(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}