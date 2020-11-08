using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Helpers
{
    public class MarsRoverException : Exception
    {
        private static readonly string _defaultMessage = "MarsRover has error.";
        private static readonly MarsRoverExceptionCode _defaultErrorCode = MarsRoverExceptionCode.OtherError;

        public MarsRoverExceptionCode MarsRoverExceptionCode { get; set; }

        public MarsRoverException() : base(_defaultMessage) 
        {
            MarsRoverExceptionCode = _defaultErrorCode;
        }
        public MarsRoverException(string message) : base(message) 
        {
            MarsRoverExceptionCode = _defaultErrorCode;
        }
        public MarsRoverException(string message, System.Exception innerException)
        : base(message, innerException) 
        {
            MarsRoverExceptionCode = _defaultErrorCode;
        }

        public MarsRoverException(string message, MarsRoverExceptionCode marsRoverExceptionCode) : base(message)
        {
            MarsRoverExceptionCode = marsRoverExceptionCode;
        }
        public MarsRoverException(string message, System.Exception innerException, MarsRoverExceptionCode marsRoverExceptionCode)
        : base(message, innerException)
        {
            MarsRoverExceptionCode = marsRoverExceptionCode;
        }
    }
}
