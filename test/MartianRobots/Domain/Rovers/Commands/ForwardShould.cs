using Amdiaz.MartianRobots.Domain.Commands;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Factories;
using Amdiaz.Test.MartianRobots.Domain.Rovers.Locations;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.Commands
{
    public class ForwardShould : CommandsModuleUnitTestCase
    {
        [Fact]
        public void be_lost()
        {
            var initialLocation = LocationMother.Random();

            var perseverance = buildRobot(initialLocation);

            var nextPosition = initialLocation.Move(1);

            shouldVerifyIfSmells(nextPosition, false);
            shouldVerifyIfCoordinatesIsOutTheTerritory(nextPosition, true);

            var command = new Forward(perseverance, terrain.Object);

            var result = command.Execute();

            shouldHaveFlavor(nextPosition);

            Assert.NotEqual(nextPosition, initialLocation);
            Assert.Equal(perseverance.BroadcastLocation(), result);
            Assert.False(perseverance.Ping());
        }

        [Theory]
        [InlineData(1, 1, Orientation.East, 2, 1)]
        [InlineData(1, 1, Orientation.North, 1, 2)]
        [InlineData(1, 1, Orientation.South, 1, 0)]
        [InlineData(1, 1, Orientation.West, 0, 1)]
        public void move_to_one_step_forward(int initialX, int initialY, Orientation orientation, int finalX, int finalY)
        {
            var perseverance = buildRobot(orientation, new Coordinates(x: initialX, y: initialY));

            var initialLocation = perseverance.BroadcastLocation();
            var expectedLocation = LocationFactory.From(orientation: orientation,
                                                        coordinates: new Coordinates(x: finalX,
                                                                                     y: finalY));

            shouldVerifyIfSmells(expectedLocation, false);
            shouldVerifyIfCoordinatesIsOutTheTerritory(expectedLocation, false);

            var command = new Forward(perseverance, terrain.Object);

            var result = command.Execute();

            Assert.NotEqual(result, initialLocation);
            Assert.Equal(result, perseverance.BroadcastLocation());
            Assert.Equal(expectedLocation, perseverance.BroadcastLocation());
        }

        [Fact]
        public void no_move_to_a_new_position()
        {
            var initialLocation = LocationMother.Random();

            var perseverance = buildRobot(initialLocation);

            var nextPosition = initialLocation.Move(1);

            shouldVerifyIfSmells(nextPosition, true);

            var command = new Forward(perseverance, terrain.Object);

            var result = command.Execute();

            Assert.NotEqual(nextPosition, initialLocation);
            Assert.Equal(initialLocation, perseverance.BroadcastLocation());
            Assert.Equal(initialLocation, result);
        }
    }
}