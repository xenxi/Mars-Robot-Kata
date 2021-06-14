using Amdiaz.MartianRobots.Domain.Exceptions;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using System;

namespace Amdiaz.MartianRobots.Infrastructure
{
    public static class OrientationStrMapper
    {
        public static Orientation From(string orientationStr)
        {
            if (string.IsNullOrWhiteSpace(orientationStr))
                throw new ArgumentNullException(nameof(orientationStr));

            orientationStr = orientationStr.Trim();

            if (string.Equals(orientationStr, "n", StringComparison.OrdinalIgnoreCase))
                return Orientation.North;

            if (string.Equals(orientationStr, "s", StringComparison.OrdinalIgnoreCase))
                return Orientation.South;
            if (string.Equals(orientationStr, "e", StringComparison.OrdinalIgnoreCase))
                return Orientation.East;
            if (string.Equals(orientationStr, "w", StringComparison.OrdinalIgnoreCase))
                return Orientation.West;

            throw new InvalidOrientationException();
        }
    }
}