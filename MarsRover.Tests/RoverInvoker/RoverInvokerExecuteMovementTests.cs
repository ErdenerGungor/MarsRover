using MarsRover.Domain;
using MarsRover.Helpers;
using MarsRover.Rover;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoverInvokerExecuteMovementTests
    {
        private RoverInvoker _roverInvoker = null;

        [SetUp]
        public async Task SetUp()
        {
            _roverInvoker = RoverInvoker.Create<RoboticRover>();
            await _roverInvoker.CreatePlateauArea("5 5");
            await _roverInvoker.SetRoverLocation("1 2 N");
        }

        [Test]
        public async Task ExecuteMovement()
        {
            await _roverInvoker.ExecuteMovement("LMLMLMLMM");

            RoverLocation roverLocation = await _roverInvoker.GetRoverLocation();
            Assert.IsNotNull(roverLocation);
            Assert.AreNotSame(roverLocation.Direction, Direction.Unknown);
            Assert.IsTrue(roverLocation.X >= 0);
            Assert.IsTrue(roverLocation.Y >= 0);
        }

        [TestCase("LMLM LMLMM")]
        [TestCase("1LMLMLMLMM")]
        [TestCase("1 2 n")]
        [TestCase("LMWLMLMLMM")]
        [TestCase("LMLMLMLMM ")]
        public async Task ExecuteMovementWithError(string movementValue)
        {

            Assert.That(async () => await _roverInvoker.SetRoverLocation(movementValue), Throws.Exception.TypeOf<MarsRoverException>());

        }
    }
}
