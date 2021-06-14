using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.Rovers.Terrains;
using Amdiaz.MartianRobots.Domain.ValueObjects;

namespace Amdiaz.MartianRobots.Factories
{
    public static class RoverFactory
    {
        public static Rover From(ITerrain terrain, int robotCurrentPositionX, int robotCurrentPositionY,
                                  Orientation robotCurrentOrientation)
        {
            var CurrentLocation = LocationFactory.From(orientation: robotCurrentOrientation,
                                                   coordinates: new Coordinates(x: robotCurrentPositionX,
                                                                                y: robotCurrentPositionY));

            return new Rover(terrain: terrain,
                             location: CurrentLocation);
        }
    }
}