using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Factories;
using MartianRobots.App.AppConsole;
using Moq;
using System;
using Xunit;

namespace MartianRobots.ConsoleApp
{
    public class ConsoleRoverStatusUpdaterShould
    {
        private readonly Mock<Action<string>> _writter;
        private readonly ConsoleRoverStatusUpdater _updater;

        public ConsoleRoverStatusUpdaterShould()
        {
            _writter = new Mock<Action<string>>();
            _updater = new ConsoleRoverStatusUpdater(_writter.Object);
        }

        [Theory]
        [InlineData(1, 1, Orientation.East, false, "1 1 E")]
        [InlineData(2, 1, Orientation.South, true, "2 1 S LOST")]
        [InlineData(2, 5, Orientation.North, true, "2 5 N LOST")]
        [InlineData(0, 0, Orientation.West, false, "0 0 W")]
        public void writte_last_position_and_status_to_theconsole(int x, int y, Orientation orientation, bool lost, string expectedOutput)
        {
            _updater.Update(location: LocationFactory.From(orientation: orientation,
                                                           coordinates: new Coordinates(x: x, y: y)),
                            lost: lost);

            _writter.Verify(x => x.Invoke(expectedOutput), Times.Once);
        }
    }
}