using Amdiaz.MartianRobots.Domain.Rovers.Terrains;

namespace Amdiaz.MartianRobots.Commands
{
    public class Forward : ICommand
    {
        private readonly IRobot _robot;
        private readonly ITerrain _surface;

        public Forward(IRobot robot, ITerrain surface)
        {
            _robot = robot;
            _surface = surface;
        }

        public void Execute()
        {
            _robot.MoveForward();
            //_robot.

            //var newLocation = _location.Move(DefaultStep);

            //if (!_surface.SmellsLikeDeadRobot(newLocation.Coordinates))
            //{
            //    _location = newLocation;
            //}

            //if (_surface.IsOnTheSurface(_location.Coordinates))
            //{
            //}

            //_location = newLocation;
        }

        public void Execute(string commandStr)
        {
            throw new System.NotImplementedException();
        }
    }

}