namespace Battlefield
{
    public struct Cell
    {
        public Cell(int xCoordinate, int yCoordinate)
            : this()
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}
