using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.Rovers.Terrains;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Factories;
using System.Collections.Generic;

namespace Amdiaz.MartianRobots.Domain
{
    public sealed class RoverCommandParameters
    {
        public RoverCommandParameters(ITerrain terrain, int robotCurrentPositionX,
                                      int robotCurrentPositionY, Orientation robotCurrentOrientation,
                                      IEnumerable<RoverCommands> commands)
        {
            Terrain = terrain;

            CurrentLocation = LocationFactory.From(orientation: robotCurrentOrientation,
                                                   coordinates: new Coordinates(x: robotCurrentPositionX,
                                                                                y: robotCurrentPositionY));
            Commands = commands;
        }

        public IEnumerable<RoverCommands> Commands { get; }
        public Location CurrentLocation { get; }
        public ITerrain Terrain { get; }
    }
}