namespace Battlefield
{
    public static class PatternFactory
    {
        public static Cell[] GenerateFirstDetonationPattern(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate =
            {
                new Cell(xCoordinate - 1, yCoordinate - 1),
                new Cell(xCoordinate + 1, yCoordinate - 1),
                new Cell(xCoordinate, yCoordinate),
                new Cell(xCoordinate - 1, yCoordinate + 1),
                new Cell(xCoordinate + 1, yCoordinate + 1)
            };

            return cellsToDetonate;
        }

        public static Cell[] GenerateSecondDetonationPattern(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate =
            {
                new Cell(xCoordinate - 1, yCoordinate - 1),
                new Cell(xCoordinate, yCoordinate - 1), 
                new Cell(xCoordinate + 1, yCoordinate - 1),
                new Cell(xCoordinate - 1, yCoordinate), 
                new Cell(xCoordinate, yCoordinate),
                new Cell(xCoordinate + 1, yCoordinate), 
                new Cell(xCoordinate - 1, yCoordinate + 1),
                new Cell(xCoordinate, yCoordinate + 1), 
                new Cell(xCoordinate + 1, yCoordinate + 1)
            };

            return cellsToDetonate;
        }

        public static Cell[] GenerateThirdDetonationPattern(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate =
            {
                new Cell(xCoordinate, yCoordinate - 2), 
                new Cell(xCoordinate - 1, yCoordinate - 1),
                new Cell(xCoordinate, yCoordinate - 1), 
                new Cell(xCoordinate + 1, yCoordinate - 1),
                new Cell(xCoordinate - 2, yCoordinate),
                new Cell(xCoordinate - 1, yCoordinate), 
                new Cell(xCoordinate, yCoordinate),
                new Cell(xCoordinate + 1, yCoordinate), 
                new Cell(xCoordinate + 2, yCoordinate), 
                new Cell(xCoordinate - 1, yCoordinate + 1),
                new Cell(xCoordinate, yCoordinate + 1), 
                new Cell(xCoordinate + 1, yCoordinate + 1),
                new Cell(xCoordinate, yCoordinate + 2)
            };

            return cellsToDetonate;
        }

        public static Cell[] GenerateFourthDetonationPattern(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate =
            {
                new Cell(xCoordinate - 1, yCoordinate - 2),
                new Cell(xCoordinate, yCoordinate - 2),
                new Cell(xCoordinate + 1, yCoordinate - 2), 
                new Cell(xCoordinate - 2, yCoordinate - 1),
                new Cell(xCoordinate - 1, yCoordinate - 1), 
                new Cell(xCoordinate, yCoordinate - 1), 
                new Cell(xCoordinate + 1, yCoordinate - 1), 
                new Cell(xCoordinate + 2, yCoordinate - 1), 
                new Cell(xCoordinate - 2, yCoordinate),
                new Cell(xCoordinate - 1, yCoordinate), 
                new Cell(xCoordinate, yCoordinate), 
                new Cell(xCoordinate + 1, yCoordinate), 
                new Cell(xCoordinate + 2, yCoordinate), 
                new Cell(xCoordinate - 2, yCoordinate + 1),
                new Cell(xCoordinate - 1, yCoordinate + 1), 
                new Cell(xCoordinate, yCoordinate + 1), 
                new Cell(xCoordinate + 1, yCoordinate + 1), 
                new Cell(xCoordinate + 2, yCoordinate + 1), 
                new Cell(xCoordinate - 1, yCoordinate + 2),
                new Cell(xCoordinate, yCoordinate + 2),
                new Cell(xCoordinate + 1, yCoordinate + 2)
            };

            return cellsToDetonate;
        }

        public static Cell[] GenerateFifthDetonationPattern(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate =
            {
                new Cell(xCoordinate - 2, yCoordinate - 2),
                new Cell(xCoordinate - 1, yCoordinate - 2),
                new Cell(xCoordinate, yCoordinate - 2),
                new Cell(xCoordinate + 1, yCoordinate - 2), 
                new Cell(xCoordinate + 2, yCoordinate - 2),
                new Cell(xCoordinate - 2, yCoordinate - 1),
                new Cell(xCoordinate - 1, yCoordinate - 1), 
                new Cell(xCoordinate, yCoordinate - 1), 
                new Cell(xCoordinate + 1, yCoordinate - 1), 
                new Cell(xCoordinate + 2, yCoordinate - 1), 
                new Cell(xCoordinate - 2, yCoordinate),
                new Cell(xCoordinate - 1, yCoordinate), 
                new Cell(xCoordinate, yCoordinate), 
                new Cell(xCoordinate + 1, yCoordinate), 
                new Cell(xCoordinate + 2, yCoordinate), 
                new Cell(xCoordinate - 2, yCoordinate + 1),
                new Cell(xCoordinate - 1, yCoordinate + 1), 
                new Cell(xCoordinate, yCoordinate + 1), 
                new Cell(xCoordinate + 1, yCoordinate + 1), 
                new Cell(xCoordinate + 2, yCoordinate + 1), 
                new Cell(xCoordinate - 2, yCoordinate + 2),
                new Cell(xCoordinate - 1, yCoordinate + 2),
                new Cell(xCoordinate, yCoordinate + 2),
                new Cell(xCoordinate + 1, yCoordinate + 2),
                new Cell(xCoordinate + 2, yCoordinate + 2),
            };

            return cellsToDetonate;
        }
    }
}
