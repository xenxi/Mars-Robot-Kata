﻿using System;
using System.Runtime.Serialization;

namespace Amdiaz.MartianRobots.Shared
{
    [Serializable]
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException()
        {
        }

        public InvalidPositionException(string message) : base(message)
        {
        }

        public InvalidPositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}