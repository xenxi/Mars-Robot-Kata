using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Exceptions;

namespace Amdiaz.MartianRobots.Infrastructure
{
    public static class RoverCommandCharMapper
    {
        public static RoverCommand From(char motionCommandChr)
        {
            motionCommandChr = char.ToLower(motionCommandChr);

            if (motionCommandChr == 'l')
                return RoverCommand.Left;

            if (motionCommandChr == 'r')
                return RoverCommand.Right;

            if (motionCommandChr == 'f')
                return RoverCommand.Forward;

            throw new InvalidCommandException();
        }
    }
}