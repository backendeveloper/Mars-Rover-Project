using System;
using System.Collections.Generic;

namespace Core
{
    public class Rover : IRover
    {
        public Rover(List<IRover> squad, ILandingSurface landingSurface, string roverPosition, string roverCommands)
        {
            Squad = squad;

            TranslateRoverPosition(roverPosition);

            if (!RoverIsWithinLandingCoordinates(landingSurface))
                return;

            TranslateRoverCommands(roverCommands);
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string DirectionFacing { get; set; }
        private List<IRover> Squad { get; set; }

        private const char MESSAGE_SEPERATOR = ' ';

        private void TranslateRoverPosition(string roverPosition)
        {
            string[] roverPositionMsgSplit = roverPosition.Split(Rover.MESSAGE_SEPERATOR);

            const int XCoordinateIdx = 0;
            const int YCoordinateIdx = 1;
            const int FacingDirectionIdx = 2;

            XCoordinate = Convert.ToInt32(roverPositionMsgSplit[XCoordinateIdx]);
            YCoordinate = Convert.ToInt32(roverPositionMsgSplit[YCoordinateIdx]);
            DirectionFacing = roverPositionMsgSplit[FacingDirectionIdx];
        }

        private static class Commands
        {
            public const string MOVE_FORWARD = "M";
            public const string ROTATE_LEFT = "L";
            public const string ROTATE_RIGHT = "R";
        }

        private void TranslateRoverCommands(string roverCommands)
        {
            var commands = roverCommands.ToCharArray();

            foreach (var command in commands)
            {
                switch (command.ToString())
                {
                    case Commands.MOVE_FORWARD:
                        MoveRoverForward();
                        break;

                    default:
                        RotateRover(command.ToString());
                        break;
                }
            }
        }

        private bool RoverIsWithinLandingCoordinates(ILandingSurface landingSurface)
        {
            return (XCoordinate >= 0) && (this.XCoordinate < landingSurface.Width) &&
                (YCoordinate >= 0) && (this.YCoordinate < landingSurface.Height);
        }

        private void MoveRoverForward()
        {
            switch (DirectionFacing)
            {
                case Facing.NORTH:
                    YCoordinate += 1;
                    break;

                case Facing.EAST:
                    XCoordinate += 1;
                    break;

                case Facing.SOUTH:
                    YCoordinate -= 1;
                    break;

                case Facing.WEST:
                    XCoordinate -= 1;
                    break;
            }
        }

        private void RotateRover(string directionCommand)
        {
            switch (directionCommand.ToUpper())
            {
                case Commands.ROTATE_LEFT:
                    TurnRoverLeft();
                    break;

                case Commands.ROTATE_RIGHT:
                    TurnRoverRight();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        private static class Facing
        {
            public const string NORTH = "N";
            public const string EAST = "E";
            public const string SOUTH = "S";
            public const string WEST = "W";
        }

        private void TurnRoverLeft()
        {
            switch (DirectionFacing)
            {
                case Facing.NORTH:
                    DirectionFacing = Facing.WEST;
                    break;

                case Facing.WEST:
                    DirectionFacing = Facing.SOUTH;
                    break;

                case Facing.SOUTH:
                    DirectionFacing = Facing.EAST;
                    break;

                case Facing.EAST:
                    DirectionFacing = Facing.NORTH;
                    break;
            }
        }

        private void TurnRoverRight()
        {
            switch (DirectionFacing)
            {
                case Facing.NORTH:
                    DirectionFacing = Facing.EAST;
                    break;

                case Facing.EAST:
                    DirectionFacing = Facing.SOUTH;
                    break;

                case Facing.SOUTH:
                    DirectionFacing = Facing.WEST;
                    break;

                case Facing.WEST:
                    DirectionFacing = Facing.NORTH;
                    break;
            }
        }
    }
}
