using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helpers
{
    public enum MarsRoverExceptionCode
    {
        Unknown = 0,
        CreatePlateauAreaError = -1,
        SetRoverLocationError = -2,
        ExecuteMovementError = -3,
        OtherError = -99,

    }
}
