using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Exceptions;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Infrastructure.Rovers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Amdiaz.MartianRobots.Infrastructure
{
    public class StringRoverCommandParamRepository : IRoverCommandParamRepository
    {
        private readonly Instructions _instructions;

        public StringRoverCommandParamRepository(string commandsStr)
        {
            _instructions = new Instructions(commandsStr);
        }

        public IEnumerable<RoverCommandParameters> GetAll()
        {
            var commandParameters = new List<RoverCommandParameters>();

            var commandLines = _instructions.Text.Split('\n', StringSplitOptions.None);

            var terrain = getTerrain(commandLines[0]);

            for (var i = 1; i < commandLines.Length;)
            {
                (int X, int Y, string OrientationStr) robotCurrentPosition = getInitialRoverPosition(commandLines[i]);

                var commands = getMovementSequence(commandLines[i + 1]);

                commandParameters.Add(
                    new RoverCommandParameters(terrain: terrain,
                                               robotCurrentPositionX: robotCurrentPosition.X,
                                               robotCurrentPositionY: robotCurrentPosition.Y,
                                               robotCurrentOrientation: OrientationStrMapper.From(robotCurrentPosition.OrientationStr),
                                               commands: commands));

                i += 2;
            }

            return commandParameters;
        }

        private static (int initialX, int initialY, string OrientationStr) getInitialRoverPosition(string roverPosition)
        {
            if (!Regex.IsMatch(roverPosition, @"^\d+ \d+ [NSEW]$", RegexOptions.IgnoreCase))
                throw new InvalidLocationException(roverPosition);

            var roverPos = Regex.Split(roverPosition, @"\s");

            return (int.Parse(roverPos[0]), int.Parse(roverPos[1]), roverPos[2].ToUpper());
        }

        private IEnumerable<RoverCommand> getMovementSequence(string motionCommandsStr)
        {
            List<RoverCommand> commands = new List<RoverCommand>();

            foreach (var character in motionCommandsStr)
                if (char.IsLetter(character))
                    commands.Add(RoverCommandCharMapper.From(character));

            return commands.ToArray();
        }

        private ITerrain getTerrain(string terrainCoordsStr)
        {
            if (!Regex.IsMatch(terrainCoordsStr, @"^\d+ \d+$"))
                throw new InvalidTerrainCoordinates(terrainCoordsStr);

            var terrain = Regex.Split(terrainCoordsStr, @"\s");

            return new MarsTerrain(int.Parse(terrain[0]), int.Parse(terrain[1]));
        }
    }
}