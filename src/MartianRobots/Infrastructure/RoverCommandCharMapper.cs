using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Exceptions;

namespace Amdiaz.MartianRobots.Infrastructure
{
    public static class RoverCommandCharMapper
    {
        public static RoverCommands From(char motionCommandChr)
        {
            motionCommandChr = char.ToLower(motionCommandChr);

            if (motionCommandChr == 'l')
                return RoverCommands.Left;

            if (motionCommandChr == 'r')
                return RoverCommands.Right;

            if (motionCommandChr == 'f')
                return RoverCommands.Forward;

            throw new InvalidCommandException();
        }
    }
}