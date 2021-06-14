using Amdiaz.MartianRobots.Domain.Rovers.Terrains;
using Amdiaz.MartianRobots.Infrastructure.Rovers;
using Amdiaz.Test.MartianRobots.Domain.Rovers.ValueObjects;

namespace Amdiaz.Test.MartianRobots.Infrastructure.Rovers
{
    public static class MarsTerrainMother
    {
        public static ITerrain Random()
        {
            var coordinates = CoordinatesMother.Ramdom();
            return new MarsTerrain(maxX: coordinates.X, maxY: coordinates.Y);
        }
    }
}