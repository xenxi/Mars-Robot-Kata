using Amdiaz.MartianRobots.Domain.Rovers.Locations;

namespace Amdiaz.MartianRobots.Domain
{
    public interface IRoverStatusUpdater
    {
        void Update(Location location, bool lost);
    }
}