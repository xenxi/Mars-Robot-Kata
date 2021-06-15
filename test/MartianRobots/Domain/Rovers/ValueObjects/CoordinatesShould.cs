using Amdiaz.MartianRobots.Domain.Exceptions;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.Test.MartianRobots.Infrastructure;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.ValueObjects
{
    public class CoordinatesShould
    {
        [Fact]
        public void create_a_valid_position()
        {
            var randomXCoordinate = MotherCreator.Random().Number(min: Coordinates.MaxCoordinateValue, max: Coordinates.MaxCoordinateValue);
            var randomYCoordinate = MotherCreator.Random().Number(min: Coordinates.MaxCoordinateValue, max: Coordinates.MaxCoordinateValue);

            Assert.NotNull(new Coordinates(x: randomXCoordinate, y: randomYCoordinate));
        }

        [Theory]
        [InlineData(Coordinates.MaxCoordinateValue + 1, 2)]
        [InlineData(Coordinates.MinCoordinateValue - 1, 2)]
        [InlineData(1, Coordinates.MaxCoordinateValue + 1)]
        [InlineData(1, Coordinates.MinCoordinateValue - 1)]
        public void throw_an_invalid_coordinates_exception(int x, int y)
        {
            Assert.Throws<InvalidCoordinatesException>(() => new Coordinates(x: x, y: y));
        }
    }
}