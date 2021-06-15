using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;

namespace Amdiaz.MartianRobots.Domain.Commands
{
    public class Forward : ICommand
    {
        private readonly Rover _rover;
        private readonly ITerrain _terrain;

        public Forward(Rover rover, ITerrain terrain)
        {
            _rover = rover;
            _terrain = terrain;
        }

        public Location Execute()
        {
            var nextPosition = _rover.MoveForward();

            var alive = _rover.Ping();

            if (!alive)
                _terrain.Flavor(nextPosition);

            return _rover.BroadcastLocation();
        }
    }
}