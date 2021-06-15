using Amdiaz.MartianRobots.Domain.ValueObjects;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public abstract class Location : ValueObject
    {
        protected Location(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; }
        protected abstract string OrientationDisplayName { get; }

        public static implicit operator Coordinates(Location l) => l.Coordinates;

        public abstract Location Move(int step);

        public override string ToString()
         => $"{Coordinates.X} {Coordinates.Y} {OrientationDisplayName}";

        public abstract Location TurnLeft();

        public abstract Location TurnRight();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OrientationDisplayName;
            yield return Coordinates;
        }
    }
}