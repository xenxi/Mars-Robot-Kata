using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Infrastructure.Rovers;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Infrastructure.Rovers
{
    public class MarsTerrainShould
    {
        [Fact]
        public void find_no_smell()
        {
            var terrain = new MarsTerrain(maxX: 2, maxY: 2);

            Assert.False(terrain.SmellsLikeDeadRobot(new Coordinates(x: 1, y: 1)));
        }

        [Fact]
        public void find_smell()
        {
            var smellCoordinate = new Coordinates(1, 1);
            var terrain = new MarsTerrain(maxX: 2, maxY: 2);

            terrain.Flavor(smellCoordinate);

            Assert.True(terrain.SmellsLikeDeadRobot(smellCoordinate));
        }

        [Theory]
        [InlineData(2, 2, 0, 0)]
        [InlineData(2, 2, 0, 1)]
        [InlineData(2, 2, 1, 1)]
        [InlineData(2, 2, 1, 2)]
        [InlineData(2, 2, 2, 2)]
        public void say_that_coordinate_is_no_out(int terrainMaxX, int terrainMaxY, int x, int y)
        {
            var terrain = new MarsTerrain(maxX: terrainMaxX, maxY: terrainMaxY);

            Assert.False(terrain.IsOut(new Coordinates(x: x, y: y)));
        }

        [Theory]
        [InlineData(2, 2, 3, 2)]
        [InlineData(2, 2, 2, 3)]
        public void say_that_coordinate_is_out(int terrainMaxX, int terrainMaxY, int x, int y)
        {
            var terrain = new MarsTerrain(maxX: terrainMaxX, maxY: terrainMaxY);

            Assert.True(terrain.IsOut(new Coordinates(x: x, y: y)));
        }
    }
}