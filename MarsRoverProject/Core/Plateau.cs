using System;

namespace Core
{
    public sealed class Plateau : ILandingSurface
    {
        public Plateau(string plateauCoordinates)
        {
            if (string.IsNullOrEmpty(plateauCoordinates))
                throw new ArgumentException();

            SplitMessageCoordinates(plateauCoordinates);
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        private const char MESSAGE_SEPERATOR = ' ';

        private void SplitMessageCoordinates(string plateauCoordinates)
        {
            var coordinateMessage = plateauCoordinates.Split(Plateau.MESSAGE_SEPERATOR);

            const int NoOfMsgValues = 2;
            const int XCoordinateIdx = 0;
            const int YCoordinateIdx = 1;

            if (coordinateMessage.Length != NoOfMsgValues)
                throw new ArgumentOutOfRangeException();

            Width = Convert.ToInt32(coordinateMessage[XCoordinateIdx]);
            Height = Convert.ToInt32(coordinateMessage[YCoordinateIdx]);
        }
    }
}
