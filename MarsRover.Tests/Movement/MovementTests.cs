using MarsRover.Domain;
using MarsRover.Movement;
using NUnit.Framework;
using System;

namespace MarsRover.Tests
{
    [TestFixture]
    public class MovementTests
    {
        [TestCase(MovementType.Right, typeof(RightMovement))]
        [TestCase(MovementType.Left, typeof(LeftMovement))]
        [TestCase(MovementType.Forward, typeof(ForwardMovement))]
        public void CreateMovementFactory(MovementType movementType, Type objectTypeOfMovement)
        {
            var movementFactory = new MovementFactory();
            var movement = movementFactory.Create(movementType);

            Assert.AreEqual(movement.GetType(), objectTypeOfMovement);
        }

        [Test]
        public void CreateMovementFactoryWithUndefinedMovementType()
        {
            var movementFactory = new MovementFactory();
            

            Assert.Throws<ArgumentNullException>(() =>
            {
                var movement = movementFactory.Create(MovementType.Unknown);
            });
        }
    }
}
