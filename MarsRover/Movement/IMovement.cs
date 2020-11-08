using MarsRover.Domain;
using MarsRover.Rover;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Movement
{
    public interface IMovement
    {
        void Run(IRover rover);
    }
}
