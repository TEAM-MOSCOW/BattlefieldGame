using System.Collections.Generic;
namespace Battlefield
{
    public static class PatternFactory
    {
        public static List<Cell> GenerateFirstDetonationPattern(Cell cell)
        {
            List<Cell> cellsToDetonate = new List<Cell>
            {
                new Cell(cell.X - 1, cell.Y - 1),
                new Cell(cell.X + 1, cell.Y - 1),
                new Cell(cell.X, cell.Y),
                new Cell(cell.X - 1, cell.Y + 1),
                new Cell(cell.X + 1, cell.Y + 1)
            };

            return cellsToDetonate;
        }

        public static List<Cell> GenerateSecondDetonationPattern(Cell cell)
        {
            List<Cell> cellsToDetonate = GenerateFirstDetonationPattern(cell);

            cellsToDetonate.Add(new Cell(cell.X, cell.Y - 1));
            cellsToDetonate.Add(new Cell(cell.X, cell.Y + 1));
            cellsToDetonate.Add(new Cell(cell.X - 1, cell.Y));
            cellsToDetonate.Add(new Cell(cell.X + 1, cell.Y));

            return cellsToDetonate;
        }

        public static List<Cell> GenerateThirdDetonationPattern(Cell cell)
        {
            List<Cell> cellsToDetonate = GenerateSecondDetonationPattern(cell);

            cellsToDetonate.Add(new Cell(cell.X, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y));

            return cellsToDetonate;
        }

        public static List<Cell> GenerateFourthDetonationPattern(Cell cell)
        {
            List<Cell> cellsToDetonate = GenerateThirdDetonationPattern(cell);

            cellsToDetonate.Add(new Cell(cell.X - 1, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X + 1, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X - 1, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X + 1, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y - 1));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y + 1));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y - 1));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y + 1));

            return cellsToDetonate;
        }

        public static List<Cell> GenerateFifthDetonationPattern(Cell cell)
        {
            List<Cell> cellsToDetonate = GenerateFourthDetonationPattern(cell);

            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y + 2));

            return cellsToDetonate;
        }
    }
}