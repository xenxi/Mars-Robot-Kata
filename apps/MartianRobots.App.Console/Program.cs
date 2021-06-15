using Amdiaz.MartianRobots.Application.SendInstructions;
using Amdiaz.MartianRobots.Domain;
using Amdiaz.MartianRobots.Infrastructure;
using System;

namespace MartianRobots.App.AppConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var consoleUpdater = new ConsoleRoverStatusUpdater(Console.WriteLine);

            var sender = new InstructionSender(commandRepo: buildExampleRepo(), updater: consoleUpdater);

            sender.Send();
        }

        private static IRoverCommandParamRepository buildExampleRepo()
        {
            var instrunctionsStr = "5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFLFLFL";

            return new StringRoverCommandParamRepository(instrunctionsStr);
        }
    }
}