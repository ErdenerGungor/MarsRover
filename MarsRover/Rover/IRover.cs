using MarsRover.Domain;

namespace MarsRover.Rover
{
    public interface IRover
    {
        PlateauArea PlateauArea { get; set; }

        RoverLocation RoverLocation { get; set; }

        void Move(RoverLocation newLocation);

        bool IsNewLocationInPlateauArea(RoverLocation newLocation);
    }
}
