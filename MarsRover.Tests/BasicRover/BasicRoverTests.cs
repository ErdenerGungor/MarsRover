using MarsRover.Domain;
using MarsRover.Helpers;
using MarsRover.Rover;
using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    [TestFixture]
    public class BasicRoverTests
    {
        [Test]
        public void CreatePlateauArea()
        {
            var plateauArea = PlateauArea.Create(5, 5);
            Assert.IsNotNull(plateauArea);
        }

        [Test]
        public void CreatePlateauAreaWithNegativeValue()
        {
            Assert.Throws<MarsRoverException>(() =>
            {
                var plateauArea = PlateauArea.Create(-3, -3);
            });
        }

        [Test]
        public void SetRoverLocation()
        {
            RoverLocation roverLocation = RoverLocation.Set(x: 1, y: 1, direction: Direction.North);

            Assert.IsNotNull(roverLocation);
        }

        [Test]
        public void SetRoverLocationWithNegativeValue()
        {

            Assert.Throws<MarsRoverException>(() =>
            {
                RoverLocation roverLocation = RoverLocation.Set(x: -1, y: -1, direction: Direction.North);
            });
        }

        [Test]
        public void SetRoverLocationWithInvalidDirection()
        {
            Assert.Throws<MarsRoverException>(() =>
            {
                RoverLocation roverLocation = RoverLocation.Set(x: 1, y: 1, direction: Direction.Unknown);
            });
        }

        [Test]
        public void RoverInvokerCreate()
        {
            RoverInvoker roverInvoker = RoverInvoker.Create<RoboticRover>();
            Assert.IsNotNull(roverInvoker);
        }
    }
}
