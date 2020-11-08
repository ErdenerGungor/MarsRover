using MarsRover.Domain;
using MarsRover.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Movement
{
    public class LeftMovement : IMovement
    {
        public void Run(IRover rover)
        {
            Direction newDirection = new Direction();
            switch (rover.RoverLocation.Direction)
            {
                case Direction.East:
                    {
                        newDirection = Direction.North;
                        break;
                    }
                case Direction.North:
                    {
                        newDirection = Direction.West;
                        break;
                    }
                case Direction.West:
                    {
                        newDirection = Direction.South;
                        break;
                    }
                case Direction.South:
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
