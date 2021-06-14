using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Locations
{
    public class East : Location
    {
        public East(Coordinates coordinates) : base(coordinates)
        {
        }

        protected override string OrientationDisplayName => "E";

        public override Location Move(int step)
            => new East(new Coordinates(x: Coordinates.X + step,
                                         y: Coordinates.Y));

        public override Location TurnLeft()
             => new North(Coordinates);

        public override Location TurnRight()
             => new South(Coordinates);
    }
}