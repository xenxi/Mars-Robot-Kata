using Amdiaz.MartianRobots.Domain.Rovers.Locations;

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

        public Location MoveForward()
        {
            var newLocation = _location.Move(1);

            _location = moveToNewLocation(newLocation);

            return newLocation;
        }

        public bool Ping()
           => _location != null;

        public void TurnLeft()
            => _location = _location.TurnLeft();

        public void TurnRight()
            => _location = _location.TurnRight();

        private Location moveToNewLocation(Location newLocation)
        {
            if (_terrain.SmellsLikeDeadRobot(newLocation.Coordinates))
                return _location;

            if (!_terrain.IsOut(newLocation.Coordinates))
                return newLocation;

            return null;
        }
    }
}