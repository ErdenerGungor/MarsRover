using MarsRover.Domain;
using MarsRover.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Movement
{
    public class ForwardMovement : IMovement
    {
        public void Run(IRover rover)
        {
            int x = rover.RoverLocation.X;
            int y = rover.RoverLocation.Y;

            switch (rover.RoverLocation.Direction)
            {
                case Direction.East:
                    {
                        x += 1;
                        break;
                    }

                case Direction.West:
                    {
                        x -= 1;
                        break;
                    }

                case Direction.North:
                    {
                        y += 1;
                        break;
                    }

                case Direction.South:
                    {
                        y -= 1;
                        break;
                    }

            }

            RoverLocation newLocation = RoverLocation.Set(x, y, rover.RoverLocation.Direction);
            rover.Move(newLocation);
        }
    }
}
