using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public class West : Location
    {
        public West(Coordinates coordinates) : base(coordinates)
        {
        }

        protected override string OrientationDisplayName => "W";

        public override Location Move(int step)
                    => new North(new Coordinates(x: Coordinates.X - step,
                                     y: Coordinates.Y));

        public override Location TurnLeft()
            => new South(Coordinates);

        public override Location TurnRight()
            => new North(Coordinates);
    }
}