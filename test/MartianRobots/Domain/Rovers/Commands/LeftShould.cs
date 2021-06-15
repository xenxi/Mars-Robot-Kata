using Amdiaz.MartianRobots.Domain.Commands;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Factories;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.Commands
{
    public class LeftShould : CommandsModuleUnitTestCase
    {
        [Theory]
        [InlineData(0, 0, Orientation.East, Orientation.North)]
        [InlineData(0, 0, Orientation.North, Orientation.West)]
        [InlineData(0, 0, Orientation.South, Orientation.East)]
        [InlineData(0, 0, Orientation.West, Orientation.South)]
        public void turn_to_left(int x, int y, Orientation initialOrientation, Orientation finalOrientation)
        {
            var initialCoordinate = new Coordinates(x: x, y: y);

            Rover perseverance = buildRobot(initialOrientation, initialCoordinate);

            var command = new Left(perseverance);

            var expectedLocation = LocationFactory.From(coordinates: initialCoordinate, orientation: finalOrientation);

            var result = command.Execute();

            Assert.Equal(expectedLocation, perseverance.BroadcastLocation());
            Assert.Equal(expectedLocation, result);
        }
    }
}