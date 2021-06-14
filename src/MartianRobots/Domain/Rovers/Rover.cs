using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.Rovers.Terrains;

namespace Amdiaz.MartianRobots.Domain.Rovers
{
    public class Rover
    {
        private readonly ITerrain _terrain;
        private Location _location;

        public Rover(Location location, ITerrain terrain)
        {
            _location = location;
            _terrain = terrain;
        }

        public Location BroadcastLocation()
            => _location;

        public bool MoveForward()
        {
            var newLocation = _location.Move(1);

            var positionChanged = canMove(newLocation);
            if (positionChanged)
                _location = newLocation;

            return positionChanged;
        }

        public override string ToString()
          => $"{_location}";

        public void TurnLeft()
             => _location = _location.TurnLeft();

        public void TurnRight()
            => _location = _location.TurnRight();

        private bool canMove(Location newLocation)
        {
            if (_terrain.SmellsLikeDeadRobot(newLocation.Coordinates))
                return true;

            if (_terrain.IsOnTheSurface(_location.Coordinates))
                return true;

            return false;
        }
    }
}