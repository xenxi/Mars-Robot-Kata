using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public abstract class Location
    {
        protected abstract string OrientationDisplayName { get; }
        protected Location(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; }

        public abstract Location Move(int step);

        public abstract Location TurnLeft();

        public abstract Location TurnRight();

        public override string ToString()
         => $"{Coordinates.X} {Coordinates.Y} {OrientationDisplayName}";
    }
}