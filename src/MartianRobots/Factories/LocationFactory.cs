using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Factories
{
    public static class LocationFactory
    {
        private static readonly Dictionary<Orientation, Func<Coordinates, Location>> _mapper = new Dictionary<Orientation, Func<Coordinates, Location>>
        {
            { Orientation.North, (c) => new North(c) },
            { Orientation.East, (c) => new East(c) },
            { Orientation.South, (c) => new South(c) },
            { Orientation.West, (c) => new West(c) }
        };

        public static Location From(Orientation orientation, Coordinates coordinates)
            => _mapper[orientation](coordinates);
    }
}