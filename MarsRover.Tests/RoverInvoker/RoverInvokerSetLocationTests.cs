using MarsRover.Domain;
using MarsRover.Helpers;
using MarsRover.Rover;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverInvokerSetLocationTests
    {
        private RoverInvoker _roverInvoker = null;

        [SetUp]
        public async Task SetUp()
        {
            _roverInvoker = RoverInvoker.Create<RoboticRover>();
            await _roverInvoker.CreatePlateauArea("5 5");
        }

        [Test]
        public async Task SetRoverLocation()
        {
            await _roverInvoker.SetRoverLocation("1 2 N");

            RoverLocation roverLocation= await _roverInvoker.GetRoverLocation();
            Assert.IsNotNull(roverLocation);
            Assert.AreNotSame(roverLocation.Direction, Direction.Unknown);
            Assert.IsTrue(roverLocation.X>=0);
            Assert.IsTrue(roverLocation.Y >= 0);
        }

        [TestCase("N 1 2")]
        [TestCase("c 5")]
        [TestCase("1 2 n")]
        [TestCase("1 W 2")]
        [TestCase("1 N W")]
        [TestCase("1 2 NW")]
        [TestCase("1 2 N W")]
        public async Task SetRoverLocationWithError(string roverLocationValue)
        {

            Assert.That(async () => await _roverInvoker.SetRoverLocation(roverLocationValue), Throws.Exception.TypeOf<MarsRoverException>());

        }
    }
}
