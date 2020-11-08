using MarsRover.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MarsRover.Helpers;

namespace MarsRover.Movement
{
    public class MovementFactory
    {
        Dictionary<MovementType, IMovement> movements = new Dictionary<MovementType, IMovement>();

        public MovementFactory()
        {
            movements.Add(MovementType.Left, new LeftMovement());
            movements.Add(MovementType.Right, new RightMovement());
            movements.Add(MovementType.Forward, new ForwardMovement());
            
        }
        public IMovement Create(MovementType movementType)
        {
            var movement=movements.Where(u => u.Key == movementType).FirstOrDefault();

            if(movement.Value==null)
                throw new ArgumentNullException("Invalid MovementType");

            return movement.Value;
        }
    }
}
