using System.Collections.Generic;
namespace Battlefield
{
    public static class PatternFactory
    {
        public static List<Cell> GenerateFirstDetonationPattern(int xCoordinate, int yCoordinate)
        {
            List<Cell> cellsToDetonate = new List<Cell>
            {
                new Cell(xCoordinate - 1, yCoordinate - 1),
                new Cell(xCoordinate + 1, yCoordinate - 1),
                new Cell(xCoordinate, yCoordinate),
                new Cell(xCoordinate - 1, yCoordinate + 1),
                new Cell(xCoordinate + 1, yCoordinate + 1)
            };

            return cellsToDetonate;
        }

        public static List<Cell> GenerateSecondDetonationPattern(int xCoordinate, int yCoordinate)
        {
            List<Cell> cellsToDetonate = GenerateFirstDetonationPattern(xCoordinate, yCoordinate);

            cellsToDetonate.Add(new Cell(xCoordinate, yCoordinate - 1));
            cellsToDetonate.Add(new Cell(xCoordinate, yCoordinate + 1));
            cellsToDetonate.Add(new Cell(xCoordinate - 1, yCoordinate));
            cellsToDetonate.Add(new Cell(xCoordinate + 1, yCoordinate));

            return cellsToDetonate;
        }

        public static List<Cell> GenerateThirdDetonationPattern(int xCoordinate, int yCoordinate)
        {
            List<Cell> cellsToDetonate = GenerateSecondDetonationPattern(xCoordinate, yCoordinate);

            cellsToDetonate.Add(new Cell(xCoordinate, yCoordinate - 2));
            cellsToDetonate.Add(new Cell(xCoordinate, yCoordinate + 2));
            cellsToDetonate.Add(new Cell(xCoordinate - 2, yCoordinate));
            cellsToDetonate.Add(new Cell(xCoordinate + 2, yCoordinate));
            
            return cellsToDetonate;
        }

        public static List<Cell> GenerateFourthDetonationPattern(int xCoordinate, int yCoordinate)
        {
            List<Cell> cellsToDetonate = GenerateThirdDetonationPattern(xCoordinate, yCoordinate);

            cellsToDetonate.Add(new Cell(xCoordinate - 1, yCoordinate - 2));
            cellsToDetonate.Add(new Cell(xCoordinate + 1, yCoordinate - 2));
            cellsToDetonate.Add(new Cell(xCoordinate - 1, yCoordinate + 2));
            cellsToDetonate.Add(new Cell(xCoordinate + 1, yCoordinate + 2));
            cellsToDetonate.Add(new Cell(xCoordinate - 2, yCoordinate - 1));
            cellsToDetonate.Add(new Cell(xCoordinate - 2, yCoordinate + 1));
            cellsToDetonate.Add(new Cell(xCoordinate + 2, yCoordinate - 1));
            cellsToDetonate.Add(new Cell(xCoordinate + 2, yCoordinate + 1));
            
            return cellsToDetonate;
        }

        public static List<Cell> GenerateFifthDetonationPattern(int xCoordinate, int yCoordinate)
        {
            List<Cell> cellsToDetonate = GenerateFourthDetonationPattern(xCoordinate, yCoordinate);

            cellsToDetonate.Add(new Cell(xCoordinate - 2, yCoordinate - 2));
            cellsToDetonate.Add(new Cell(xCoordinate - 2, yCoordinate + 2));
            cellsToDetonate.Add(new Cell(xCoordinate + 2, yCoordinate - 2));
            cellsToDetonate.Add(new Cell(xCoordinate + 2, yCoordinate + 2));

            return cellsToDetonate;
        }
    }
}
