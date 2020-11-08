using MarsRover.Helpers;
using System;

namespace MarsRover.Domain
{
    public class RoverLocation
    {
        private const int minRoverLocationValue = 0;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Direction Direction { get; private set; }

        private RoverLocation(int x, int y, Direction direction)
        {
            this.X = x.EnsureMinValue(minRoverLocationValue);
            this.Y = y.EnsureMinValue(minRoverLocationValue);
            this.Direction = direction;
        }

        public static RoverLocation Set(int x, int y, Direction direction)
        {
            if (!isValidDirection(direction))
                throw new MarsRoverException("Please enter the valid direction", MarsRoverExceptionCode.SetRoverLocationError);

            if (!x.IsGreaterThanEqual(minRoverLocationValue))
                throw new MarsRoverException("Location X does not have valid value", MarsRoverExceptionCode.SetRoverLocationError);

            if (!y.IsGreaterThanEqual(minRoverLocationValue))
                throw new MarsRoverException("Location Y does not have valid value", MarsRoverExceptionCode.SetRoverLocationError);

            return new RoverLocation(x, y,direction);
        }

        private static bool isValidDirection(Direction direction)
        {
            if (direction == Direction.Unknown)
                return false;

            return true;
        }
    }
}
