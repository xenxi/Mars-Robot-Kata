using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers
{
    public interface ITerrain
    {
        public bool IsOut(Coordinates coordinates);

        public bool SmellsLikeDeadRobot(Coordinates coordinates);

        void Flavor(Coordinates coordinates);
    }
}