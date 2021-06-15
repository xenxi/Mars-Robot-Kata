using Amdiaz.MartianRobots.Domain.Rovers.Locations;

namespace Amdiaz.MartianRobots.Commands
{
    public interface ICommand
    {
        Location Execute();
    }
}