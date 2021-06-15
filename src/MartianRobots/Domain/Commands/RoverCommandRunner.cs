using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Exceptions;
using Amdiaz.MartianRobots.Domain.Rovers;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amdiaz.MartianRobots.Domain.Commands
{
    public class RoverCommandRunner
    {
        private readonly Dictionary<RoverCommand, Func<ICommand>> _commandMap;
        private readonly Rover _rover;
        private readonly ITerrain _terrain;

        public RoverCommandRunner(Rover rover, ITerrain terrain)
        {
            _rover = rover;
            _terrain = terrain;

            _commandMap = new Dictionary<RoverCommand, Func<ICommand>>
            {
                { RoverCommand.Forward, buildForwardCommand },
                { RoverCommand.Right, buildRightCommand },
                { RoverCommand.Left, buildLeftCommand },
            };
        }

        public Location Execute(RoverCommandParameters roverInstruction)
        {
            var cursor = roverInstruction.Commands.GetEnumerator();

            var lastKnownPosition = _rover.BroadcastLocation();

            while (cursor.MoveNext() && _rover.Ping())
            {
                var aux = executeCommand(cursor.Current);

                if (aux != null)
                    lastKnownPosition = aux;
            }
            return lastKnownPosition;
        }

        private ICommand buildForwardCommand()
            => new Forward(_rover, _terrain);

        private ICommand buildLeftCommand()
         => new Left(_rover);

        private ICommand buildRightCommand()
        => new Right(_rover);

        private Location executeCommand(RoverCommand command)
        {
            var action = _commandMap.SingleOrDefault(x => x.Key == command);

            if (action.Value != null)
                return action.Value.Invoke().Execute();

            throw new InvalidCommandException();
        }
    }
}