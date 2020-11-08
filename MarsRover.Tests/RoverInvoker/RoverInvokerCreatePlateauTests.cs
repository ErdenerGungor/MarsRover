using MarsRover.Helpers;
using MarsRover.Rover;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverInvokerCreatePlateauTests
    {
        private RoverInvoker _roverInvoker = null;

        [SetUp]
        public void SetUp()
        {
            _roverInvoker = RoverInvoker.Create<RoboticRover>();
        }

        [Test]
        public async Task CreatePlateauWithInvoker()
        {
            await _roverInvoker.CreatePlateauArea("5 5");
        }

        [Test]
        public async Task CreatePlateauWithInvokerTwoDigits()
        {
            await _roverInvoker.CreatePlateauArea("53 51");
        }

        [TestCase("5 a")]
        [TestCase("c 5")]
        [TestCase("a5 3")]
        [TestCase("5  3")]
        [TestCase("5a3")]
        [TestCase("-1 3")]
        public async Task CreatePlateauAreaWithError(string plateauAreaValue)
        {

            Assert.That(async () => await _roverInvoker.CreatePlateauArea(plateauAreaValue), Throws.Exception.TypeOf<MarsRoverException>());

        }
    }
}
