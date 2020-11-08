using MarsRover.Domain;
using MarsRover.Helpers;
using MarsRover.Rover;
using System;
using System.Threading.Tasks;

namespace MarsRover.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool toBeContinue = false;

            do
            {
                await Start();

                System.Console.WriteLine("Do you want to start again? If yes, please enter key 'Y'");

                ConsoleKeyInfo toBeContinueAnswer = System.Console.ReadKey();
                toBeContinue = toBeContinueAnswer.KeyChar == Constants.Characters.Y;

                if (toBeContinue)
                {
                    System.Console.WriteLine("");
                    System.Console.WriteLine("A squad of robotic rovers are landing on a plateau on Mars again.");
                }

            } while (toBeContinue);

            System.Console.ReadKey();
        }

        static async Task Start()
        {
            try
            {
                System.Console.WriteLine("Welcome to plateau on Mars.");

                RoverInvoker roverInvoker = RoverInvoker.Create<RoboticRover>();

                #region CreatePlateauArea

                System.Console.WriteLine("Please enter the plateau area such as 5 5");

                var plateauAreaValue = System.Console.ReadLine();

                await roverInvoker.CreatePlateauArea(plateauAreaValue);

                System.Console.WriteLine("Plateau area is configured succesfully.");

                #endregion CreatePlateauArea

                #region SetLocation

                System.Console.WriteLine("Please enter rover start location such as : 1 2 N");

                var roverLocationValue = System.Console.ReadLine();
                await roverInvoker.SetRoverLocation(roverLocationValue);

                System.Console.WriteLine("Rover start location is configured succesfully.");

                #endregion SetLocation

                #region ExecuteMovement

                System.Console.WriteLine("Please enter movement Instruction such as : LMLMLMLMM");

                var movementValue = System.Console.ReadLine();

                await roverInvoker.ExecuteMovement(movementValue);

                System.Console.WriteLine("Rover moved");

                #endregion ExecuteMovement

                System.Console.WriteLine("Your rover current location");

                RoverLocation roverLocation = await roverInvoker.GetRoverLocation();

                System.Console.WriteLine($"{roverLocation.X} {roverLocation.Y} {(char)roverLocation.Direction}");
            }
            catch (MarsRoverException rex)
            {
                System.Console.WriteLine("Invalid Command. " + rex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("MarsRover has unknown error : " + ex.Message);
            }
        }
    }
}
