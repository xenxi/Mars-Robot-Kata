using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public class North : Location
    {
        public North(Coordinates coordinates) : base(coordinates)
        {
        }

        protected override string OrientationDisplayName => "N";

        public override Location Move(int step)
                    => new North(new Coordinates(x: Coordinates.X,
                                         y: Coordinates.Y + step));

        public override Location TurnLeft()
            => new West(Coordinates);

        public override Location TurnRight()
            => new East(Coordinates);
    }
}