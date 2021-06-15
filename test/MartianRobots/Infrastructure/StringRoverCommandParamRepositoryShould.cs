using Amdiaz.MartianRobots.Commands;
using Amdiaz.MartianRobots.Domain.Exceptions;
using Amdiaz.MartianRobots.Domain.Rovers.Locations;
using Amdiaz.MartianRobots.Infrastructure;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Amdiaz.Test.MartianRobots.Infrastructure
{
    public class StringRoverCommandParamRepositoryShould
    {
        [Theory]
        [InlineData("5 3\n1 5 E\nRFRL")]
        public void receive_a_valid_param(string command)
        {
            var repo = new StringRoverCommandParamRepository(command);

            var result = repo.GetAll();

            Assert.Single(result);

            var param = result.First();

            Assert.Equal(1, param.CurrentLocation.Coordinates.X);
            Assert.Equal(5, param.CurrentLocation.Coordinates.Y);
            Assert.Equal(typeof(East), param.CurrentLocation.GetType());
            Assert.Equal(4, param.Commands.Count());

            param.Commands
                 .Should()
                 .ContainInOrder(RoverCommand.Right,
                                 RoverCommand.Forward,
                                 RoverCommand.Right,
                                 RoverCommand.Left);
        }

        [Theory]
        [InlineData("5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFLFLFL")]
        public void receive_three_communications_parameters(string command)
        {
            var repo = new StringRoverCommandParamRepository(command);

            var result = repo.GetAll();

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void throw_argument_null_exception()
        {
            Assert.Throws<ArgumentNullException>(() => new StringRoverCommandParamRepository(null));
            Assert.Throws<ArgumentNullException>(() => new StringRoverCommandParamRepository(""));
        }

        [Fact]
        public void throw_argument_out_of_range_exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new StringRoverCommandParamRepository(MotherCreator
                .Random()
                .String(length: 101)));
        }

        [Theory]
        [InlineData("5 1\n1 -1 E\nRFRFRFRF")]
        [InlineData("5 1\n1 1 L\nRFRFRFRF")]
        [InlineData("5 1\n1 1 1 E\nRFRFRFRF")]
        public void throw_invalid_location(string command)
        {
            Assert.Throws<InvalidLocationException>(() => new StringRoverCommandParamRepository(command).GetAll());
        }

        [Theory]
        [InlineData("5 a\n1 1 E\nRFRFRFRF")]
        [InlineData("5 3 5\n1 1 E\nRFRFRFRF")]
        [InlineData("5 -3 \n1 1 E\nRFRFRFRF")]
        public void throw_invalid_terrain_coordinates(string command)
        {
            Assert.Throws<InvalidTerrainCoordinates>(() => new StringRoverCommandParamRepository(command).GetAll());
        }
    }
}