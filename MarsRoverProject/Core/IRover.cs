namespace Core
{
    public interface IRover
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        string DirectionFacing { get; set; }
    }
}
