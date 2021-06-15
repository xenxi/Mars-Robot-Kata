using Amdiaz.MartianRobots.Application.SendInstructions;
using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Infrastructure.Rovers;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Application.SendInstructions
{
    public class InstructionSenderShould
    {
        private readonly Mock<IRoverCommandParamRepository> _repository;
        private readonly InstructionSender _sender;
        private readonly Mock<IRoverStatusUpdater> _updater;

        public InstructionSenderShould()
        {
            _repository = new Mock<IRoverCommandParamRepository>();
            _updater = new Mock<IRoverStatusUpdater>();

            _sender = new InstructionSender(_repository.Object, _updater.Object);
        }

        [Fact]
        public void move_robot()
        {
            var param = new RoverCommandParameters(terrain: new MarsTerrain(maxX: 5, maxY: 3),
                robotCurrentPositionX: 1,
                robotCurrentPositionY: 1,
                robotCurrentOrientation: Orientation.East,
                commands: new List<RoverCommand>()
                {
                    RoverCommand.Right,
                    RoverCommand.Forward,
                    RoverCommand.Right,
                    RoverCommand.Forward,
                    RoverCommand.Right,
                    RoverCommand.Forward,
                    RoverCommand.Right,
                    RoverCommand.Forward,
                });
            var expectedLastLocation = new East(new Coordinates(x: 1, y: 1));

            shouldSearchForParams(new List<RoverCommandParameters>() { param });

            _sender.Send();

            shouldHaveNotifyUpdates(expectedLastLocation, lost: false);
        }

        [Fact]
        public void send_and_notify_lost_robot()
        {
            var param = new RoverCommandParameters(terrain: new MarsTerrain(maxX: 5, maxY: 3),
                robotCurrentPositionX: 3,
                robotCurrentPositionY: 2,
                robotCurrentOrientation: Orientation.North,
                commands: new List<RoverCommand>()
                {
                    RoverCommand.Forward,
                    RoverCommand.Forward,
                    RoverCommand.Forward,
                });
            var expectedLastLocation = new North(new Coordinates(x: 3, y: 3));

            shouldSearchForParams(new List<RoverCommandParameters>() { param });

            _sender.Send();

            shouldHaveNotifyUpdates(expectedLastLocation, lost: true);
        }

        [Fact]
        public void send_and_notify_no_lost_robot()
        {
            var param = new RoverCommandParameters(terrain: new MarsTerrain(maxX: 5, maxY: 10),
                robotCurrentPositionX: 3,
                robotCurrentPositionY: 2,
                robotCurrentOrientation: Orientation.North,
                commands: new List<RoverCommand>()
                {
                    RoverCommand.Forward,
                    RoverCommand.Forward,
                    RoverCommand.Forward,
                });
            var expectedLastLocation = new North(new Coordinates(x: 3, y: 5));

            shouldSearchForParams(new List<RoverCommandParameters>() { param });

            _sender.Send();

            shouldHaveNotifyUpdates(expectedLastLocation, lost: false);
        }

        private void shouldHaveNotifyUpdates(Location location, bool lost)
            => _updater.Verify(x => x.Update(location, lost), Times.Once);

        private void shouldSearchForParams(IEnumerable<RoverCommandParameters> @params)
             => _repository.Setup(x => x.GetAll()).Returns(@params);
    }
}