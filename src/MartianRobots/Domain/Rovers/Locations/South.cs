using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public class South : Location
    {
        public South(Coordinates coordinates) : base(coordinates)
        {
        }

        protected override string OrientationDisplayName => "S";

        public override Location Move(int step)
                => new North(new Coordinates(x: Coordinates.X,
                                     y: Coordinates.Y - step));

        public override Location TurnLeft()
            => new East(Coordinates);

        public override Location TurnRight()
            => new West(Coordinates);
    }
}