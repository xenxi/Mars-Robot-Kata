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

        [Fact]
        public void throw_an_invalid_coordinates_exception()
        {
            Assert.Throws<InvalidCoordinatesException>(() => new Coordinates(x: Coordinates.MaxCoordinateValue + 1, y: 2));
            Assert.Throws<InvalidCoordinatesException>(() => new Coordinates(x: Coordinates.MinCoordinateValue - 1, y: 2));

            Assert.Throws<InvalidCoordinatesException>(() => new Coordinates(x: 1, y: Coordinates.MaxCoordinateValue + 1));
            Assert.Throws<InvalidCoordinatesException>(() => new Coordinates(x: 1, y: Coordinates.MinCoordinateValue - 1));
        }
    }
}