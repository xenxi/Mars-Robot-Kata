using Amdiaz.MartianRobots.Application.SendInstructions;
using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Domain.ValueObjects;
using Amdiaz.MartianRobots.Infrastructure.Rovers;
using Amdiaz.Test.MartianRobots.Domain;
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
        public void send_and_notify_robot()
        {
            var param = RoverCommandParametersMother.Random();

            shouldSearchForParams(new List<RoverCommandParameters>() { param });

            _sender.Send();

            shouldHaveNotifyUpdates();
        }

        [Fact]
        public void send_and_notify_lost_robot()
        {
            var param = new RoverCommandParameters(terrain: new MarsTerrain(maxX: 5, maxY: 3),
                robotCurrentPositionX: 3,
                robotCurrentPositionY: 2,
                robotCurrentOrientation: Orientation.North,
                commands: new List<RoverCommands>()
                {
                    RoverCommands.Forward,
                    RoverCommands.Forward,
                    RoverCommands.Forward,
                });

            shouldSearchForParams(new List<RoverCommandParameters>() { param });
            shouldNotifyUpdates("3 3 N PERDIDO");

            _sender.Send();
        }

        private void shouldHaveNotifyUpdates()
            => _updater.Verify(x => x.Update(It.IsAny<string>()), Times.AtLeastOnce);

        private void shouldNotifyUpdates(string command)
            => _updater.Verify(x => x.Update(command), Times.Once);

        private void shouldSearchForParams(IEnumerable<RoverCommandParameters> @params)
             => _repository.Setup(x => x.GetAll()).Returns(@params);
    }
}