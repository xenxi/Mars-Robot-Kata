using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using System;

namespace MartianRobots.App.AppConsole
{
    public class ConsoleRoverStatusUpdater : IRoverStatusUpdater
    {
        private readonly Action<string> _writteLine;

        public ConsoleRoverStatusUpdater(Action<string> writteLine)
        {
            _writteLine = writteLine;
        }

        public void Update(Location location, bool lost)
        {
            _writteLine.Invoke($"{location}{statusToString(lost)}");
        }

        private string statusToString(bool lost)
            => lost ? " LOST" : string.Empty;
    }
}