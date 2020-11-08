using MarsRover.Domain;
using MarsRover.Helpers;
using System;

namespace MarsRover.Rover
{
    public class RoboticRover : IRover
    {
        public PlateauArea PlateauArea { get; set; }

        public RoverLocation RoverLocation { get; set; }

        public void Move(RoverLocation newLocation)
        {
            if (!IsNewLocationInPlateauArea(newLocation))
                throw new MarsRoverException("The rover location is outside the plateau area", MarsRoverExceptionCode.ExecuteMovementError);

            this.RoverLocation = newLocation;
        }

        public bool IsNewLocationInPlateauArea(RoverLocation newLocation)
        {
            if (newLocation.X > this.PlateauArea.Width)
                return false;
            if (newLocation.Y > this.PlateauArea.Height)
                return false;
            return true;

        }
    }
}
