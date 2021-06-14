using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Domain.Rovers.Terrains
{
    public interface ITerrain
    {
        public bool IsOnTheSurface(Coordinates position);

        public bool SmellsLikeDeadRobot(Coordinates position);


    }
}