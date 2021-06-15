using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Factories;
using Moq;

namespace Amdiaz.Test.MartianRobots.Domain.Rovers.Commands
{
    public abstract class CommandsModuleUnitTestCase
    {
        protected readonly Mock<ITerrain> terrain;

        protected CommandsModuleUnitTestCase()
        {
            terrain = new Mock<ITerrain>();
        }

        protected Rover buildRobot(Orientation initialOrientation, Coordinates initialCoordinate)
            => new Rover(
                location: LocationFactory.From(coordinates: initialCoordinate,
                                               orientation: initialOrientation),
                terrain: terrain.Object);

        protected Rover buildRobot(Location location)
             => new Rover(location: location,
                          terrain: terrain.Object);

        protected void shouldVerifyIfCoordinatesIsOutTheTerritory(Coordinates coordinates, bool isOut)
            => terrain.Setup(x => x.IsOut(coordinates)).Returns(isOut);

        protected void shouldVerifyIfSmells(Coordinates coordinates, bool smell)
                   => terrain.Setup(x => x.SmellsLikeDeadRobot(coordinates)).Returns(smell);


        protected void shouldHaveFlavor(Coordinates coordinates)
            => terrain.Verify(x => x.Flavor(coordinates), Times.AtLeastOnce);
    }
}