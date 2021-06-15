using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;

namespace Amdiaz.MartianRobots.Domain.Commands
{
    public class Right : ICommand
    {
        private readonly Rover _rover;

        public Right(Rover rover)
        {
            _rover = rover;
        }

        public Location Execute()
        {
            _rover.TurnRight();

            return _rover.BroadcastLocation();
        }
    }
}