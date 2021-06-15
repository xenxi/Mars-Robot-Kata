using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Domain.Commands;
using Amdiaz.MartianRobots.Domain.Rovers;
using System.Linq;

namespace Amdiaz.MartianRobots.Application.SendInstructions
{
    public class InstructionSender
    {
        private readonly IRoverCommandParamRepository _commandRepo;
        private readonly IRoverStatusUpdater _updater;

        public InstructionSender(IRoverCommandParamRepository commandRepo, IRoverStatusUpdater updater)
        {
            _commandRepo = commandRepo;
            _updater = updater;
        }

        public void Send()
        {
            var instructions = _commandRepo
                .GetAll()
                .Where(x => x.Commands.Any());

            foreach (var roverInstruction in instructions)
            {
                var perseverance = new Rover(terrain: roverInstruction.Terrain,
                                             location: roverInstruction.CurrentLocation);

                var commandRunner = new RoverCommandRunner(rover: perseverance,
                                                           terrain: roverInstruction.Terrain);

                var lastKnownPosition = commandRunner.Execute(roverInstruction);

                _updater.Update(lastKnownPosition, lost: !perseverance.Ping());
            }
        }
    }
}