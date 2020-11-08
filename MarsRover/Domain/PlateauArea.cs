using MarsRover.Helpers;

namespace MarsRover.Domain
{
    public class PlateauArea
    {
        private const int minPlateauAreaValue = 1;
        public int Width { get; private set; }
        public int Height { get; private set; }

        private PlateauArea(int width,int height)
        {
            Width = width.EnsureMinValue(minPlateauAreaValue);
            Height = height.EnsureMinValue(minPlateauAreaValue);
        }

        public static PlateauArea Create(int width, int height)
        {
            if (!width.IsGreaterThanEqual(minPlateauAreaValue))
                throw new MarsRoverException("Width does not have valid value", MarsRoverExceptionCode.CreatePlateauAreaError);

            if (!height.IsGreaterThanEqual(minPlateauAreaValue))
                throw new MarsRoverException("Height does not have valid value", MarsRoverExceptionCode.CreatePlateauAreaError);

            return new PlateauArea(width, height);
        }
    }
}
