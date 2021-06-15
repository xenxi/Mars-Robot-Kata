using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;

namespace Amdiaz.MartianRobots.Domain.Commands
{
    public class Left : ICommand
    {
        private readonly Rover _rover;

        public Left(Rover rover)
        {
            _rover = rover;
        }

        public Location Execute()
        {
            _rover.TurnLeft();

            return _rover.BroadcastLocation();
        }
    }
}