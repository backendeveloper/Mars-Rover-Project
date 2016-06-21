using System.Collections.Generic;

namespace Core
{
    public class RoverSquad : List<IRover>
    {
        public RoverSquad(ILandingSurface landingSurface)
        {
            LandingSurface = landingSurface;
        }

        private ILandingSurface LandingSurface { get; }

        public void DeployNewRover(string roverPosition, string roverCommands)
        {
            Add(new Rover(this, this.LandingSurface, roverPosition, roverCommands));
        }
    }
}
