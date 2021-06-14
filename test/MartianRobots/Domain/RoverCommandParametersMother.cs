using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.Test.MartianRobots.Domain.Rovers.ValueObjects;
using Amdiaz.Test.MartianRobots.Infrastructure;
using Amdiaz.Test.MartianRobots.Infrastructure.Rovers;
using System.Collections.Generic;

namespace Amdiaz.Test.MartianRobots.Domain
{
    public static class RoverCommandParametersMother
    {
        public static RoverCommandParameters Random()
        {
            var initialPosition = CoordinatesMother.Ramdom();
            return new RoverCommandParameters(terrain: MarsTerrainMother.Random(),
                                              robotCurrentPositionX: initialPosition.X,
                                              robotCurrentPositionY: initialPosition.Y,
                                              robotCurrentOrientation: MotherCreator.Random().Enum<Orientation>(),
                                              commands: randomCommands());
        }

        private static IEnumerable<RoverCommands> randomCommands()
        {
            var commands = new List<RoverCommands>();
            for (int i = 0; i < MotherCreator.Random().Number(max: 10, min: 1); i++)
                commands.Add(MotherCreator.Random().Enum<RoverCommands>());

            return commands;
        }
    }
}