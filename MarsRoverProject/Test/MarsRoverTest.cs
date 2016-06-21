using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void DeployRoversTest()
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            var roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

            const int NoRovers = 2;
            const int RoverOneIdx = 0;
            const int RoverTwoIdx = 1;

            Assert.IsTrue(roverSquad.Count == NoRovers);

            var roverOne = roverSquad[RoverOneIdx];
            var roverTwo = roverSquad[RoverTwoIdx];

            Assert.IsNotNull(roverOne);
            Assert.IsNotNull(roverTwo);
        }

        [TestMethod]
        public void DeployRoversAndTestCoordinates()
        {
            ILandingSurface landingSurface = new Plateau("5 5");
            var roverSquad = new RoverSquad(landingSurface);

            roverSquad.DeployNewRover("1 2 N", "LMLMLMLMM");
            roverSquad.DeployNewRover("3 3 E", "MMRMMRMRRM");

            const int RoverOneIdx = 0;
            const int RoverTwoIdx = 1;

            var roverOne = roverSquad[RoverOneIdx];
            var roverTwo = roverSquad[RoverTwoIdx];

            Assert.IsTrue(roverOne.XCoordinate == 1, "RoverOne: X != 1");
            Assert.IsTrue(roverOne.YCoordinate == 3, "RoverOne: Y != 3");
            Assert.IsTrue(roverOne.DirectionFacing == "N", "RoverOne: Direction != North");

            Assert.IsTrue(roverTwo.XCoordinate == 5, "RoverTwo: X != 5");
            Assert.IsTrue(roverTwo.YCoordinate == 1, "RoverTwo: Y != 1");
            Assert.IsTrue(roverTwo.DirectionFacing == "E", "RoverTwo: Direction != East");
        }
    }
}
