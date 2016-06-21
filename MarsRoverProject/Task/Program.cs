using System;
using Core;

namespace Task
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Test Input:");

            var plateauString = Console.ReadLine();
            ILandingSurface landingSurface = new Plateau(plateauString);
            var roverSquad = new RoverSquad(landingSurface);

            var deployRoverString1 = Console.ReadLine();
            var deployMoveString1 = Console.ReadLine();
            var deployRoverString2 = Console.ReadLine();
            var deployMoveString2 = Console.ReadLine();

            roverSquad.DeployNewRover(deployRoverString1, deployMoveString1);
            roverSquad.DeployNewRover(deployRoverString2, deployMoveString2);

            const int RoverOneIdx = 0;
            const int RoverTwoIdx = 1;

            var roverOne = roverSquad[RoverOneIdx];
            var roverTwo = roverSquad[RoverTwoIdx];

            Console.WriteLine("\nExpected Output:\n");
            Console.WriteLine($"{roverOne.XCoordinate} {roverOne.YCoordinate} {roverOne.DirectionFacing}");
            Console.WriteLine($"{roverTwo.XCoordinate} {roverTwo.YCoordinate} {roverTwo.DirectionFacing}");

            Console.Write("Press <enter> to exit...");
            Console.ReadLine();
        }
    }
}
