using MarsRover.Domain;
using MarsRover.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Movement
{
    public class RightMovement : IMovement
    {
        public void Run(IRover rover)
        {
            var newDirection = new Direction();
            switch (rover.RoverLocation.Direction)
            {
                case Direction.East:
                    {
                        newDirection = Direction.South;
                        break;
                    }
                case Direction.South:
                    {
                        newDirection = Direction.West;
                        break;
                    }
                case Direction.West:
                    {
                        newDirection = Direction.North;
                        break;
                    }
                case Direction.North:
                    {
                        newDirection = Direction.East;
                        break;
                    }
            }

            RoverLocation newLocation = RoverLocation.Set(rover.RoverLocation.X, rover.RoverLocation.Y, newDirection);
            rover.Move(newLocation);
        }
    }
}
