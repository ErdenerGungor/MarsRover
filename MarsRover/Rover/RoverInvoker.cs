using MarsRover.Domain;
using MarsRover.Helpers;
using MarsRover.Movement;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsRover.Rover
{
    public class RoverInvoker
    {
        private IRover _rover { get; set; }

        private RoverInvoker(IRover iRover)
        {
            this._rover = iRover;
        }

        public static RoverInvoker Create<T>() where T : IRover
        {
            T instance = (T)Activator.CreateInstance(typeof(T));
            return new RoverInvoker(instance);
        }

        public async Task<RoverInvoker> CreatePlateauArea(string plateauAreaValue)
        {
            if (!canCreatePlateauArea(plateauAreaValue))
            {
                throw new MarsRoverException("Please check your plateau area command. It should be '5 5'",MarsRoverExceptionCode.CreatePlateauAreaError);
            }

            var values = plateauAreaValue.Split(new char[] { Constants.Characters.Space }, StringSplitOptions.RemoveEmptyEntries);
            int width = values[0].ToInt32();
            int height = values[1].ToInt32();

            this._rover.PlateauArea = PlateauArea.Create(width, height);

            return this;
        }

        public async Task<RoverInvoker> SetRoverLocation(string roverLocationValue)
        {
            if (!canSetRoverLocation(roverLocationValue))
            {
                throw new MarsRoverException("Please check rover start location. It should be '1 1 N'", MarsRoverExceptionCode.SetRoverLocationError);
            }

            var values = roverLocationValue.Split(new char[] { Constants.Characters.Space }, StringSplitOptions.RemoveEmptyEntries);
            int x = values[0].ToInt32();
            int y = values[1].ToInt32();
            Direction direction = (Direction)char.Parse(values[2]);

            RoverLocation roverLocation = RoverLocation.Set(x, y, direction);

            if (!_rover.IsNewLocationInPlateauArea(roverLocation))
            {
                throw new MarsRoverException("The rover start location is outside the plateau area.", MarsRoverExceptionCode.SetRoverLocationError);
            }

            this._rover.RoverLocation = roverLocation;

            return this;
        }

        public async Task<RoverInvoker> ExecuteMovement(string movementValue)
        {
            if (!canBeMove(movementValue))
            {
                throw new MarsRoverException("Please check rover movement type. You can use only LRM movement.", MarsRoverExceptionCode.ExecuteMovementError);
            }

            MovementFactory movementFactory = new MovementFactory();

            foreach (var c in movementValue)
            {
                MovementType movementType = (MovementType)char.ToUpper(c);
                var move = movementFactory.Create(movementType);
                move.Run(this._rover);
            }

            return this;
        }

        public async Task<RoverLocation> GetRoverLocation()
        {
            return this._rover.RoverLocation;
        }

        private bool canCreatePlateauArea(string areaInput)
        {
            if (string.IsNullOrEmpty(areaInput)) return false;

            bool isValidInput = Regex.IsMatch(areaInput, @"^\d+?\s\d+$");

            return isValidInput;

        }

        private bool canSetRoverLocation(string locationInput)
        {
            if (string.IsNullOrEmpty(locationInput)) return false;

            bool isValidInput = Regex.IsMatch(locationInput, @"^\d+?\s\d+\s[NSEW]$");

            return isValidInput;

        }

        private bool canBeMove(string moveInput)
        {
            if (string.IsNullOrEmpty(moveInput)) return false;

            bool isValidInput = Regex.IsMatch(moveInput, @"^[LRM]*$");

            return isValidInput;

        }
    }
}
