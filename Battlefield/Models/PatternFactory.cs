namespace Battlefield
{
    using System.Collections.Generic;

    /// <summary>
    /// Static class responsible for generating the detonation patterns for different types of mines.
    /// </summary>
    public static class PatternFactory
    {
        /// <summary>
        /// Method that shows the explosion pattern of a mine with the value of 1.
        /// </summary>
        /// <param name="cell">Contains the coordinates of the detonated mine.</param>
        /// <returns>List of Cells that are affected by the explosion</returns>
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

        /// <summary>
        /// Method that shows the explosion pattern of a mine with the value of 2. 
        /// </summary>
        /// <param name="cell">Contains the coordinates of the detonated mine.</param>
        /// <returns>List of Cells that are affected by the explosion</returns>
        public static List<Cell> GenerateSecondDetonationPattern(Cell cell)
        {
            /*
             * the pattern of a mine with the value of 2 is similar to the pattern of a mine with the value of 1
             * so we assign a variable to the method GenerateFirstDetonationPattern
             */
            List<Cell> cellsToDetonate = GenerateFirstDetonationPattern(cell);

            /*
             * then we add the additional Cells 
             */
            cellsToDetonate.Add(new Cell(cell.X, cell.Y - 1));
            cellsToDetonate.Add(new Cell(cell.X, cell.Y + 1));
            cellsToDetonate.Add(new Cell(cell.X - 1, cell.Y));
            cellsToDetonate.Add(new Cell(cell.X + 1, cell.Y));

            return cellsToDetonate;
        }

        /// <summary>
        /// Method that shows the explosion pattern of a mine with the value of 3.
        /// </summary>
        /// <param name="cell">Contains the coordinates of the detonated mine.</param>
        /// <returns>List of Cells that are affected by the explosion</returns>
        public static List<Cell> GenerateThirdDetonationPattern(Cell cell)
        {
            /*
             * the pattern of a mine with the value of 2 is similar to the pattern of a mine with the value of 1
             * so we assign a variable to the method GenerateSecondDetonationPattern
             */
            List<Cell> cellsToDetonate = GenerateSecondDetonationPattern(cell);

            /*
             * then we add the additional Cells 
             */
            cellsToDetonate.Add(new Cell(cell.X, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y));

            return cellsToDetonate;
        }

        /// <summary>
        /// Method that shows the explosion pattern of a mine with the value of 4.
        /// </summary>
        /// <param name="cell">Contains the coordinates of the detonated mine.</param>
        /// <returns>List of Cells that are affected by the explosion</returns>
        public static List<Cell> GenerateFourthDetonationPattern(Cell cell)
        {
            /*
             * the pattern of a mine with the value of 2 is similar to the pattern of a mine with the value of 1
             * so we assign a variable to the method GenerateSecondDetonationPattern
             */
            List<Cell> cellsToDetonate = GenerateThirdDetonationPattern(cell);

            /*
             * then we add the additional Cells 
             */
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

        /// <summary>
        /// Method that shows the explosion pattern of a mine with the value of 5.
        /// </summary>
        /// <param name="cell">Contains the coordinates of the detonated mine.</param>
        /// <returns>List of Cells that are affected by the explosion</returns>
        public static List<Cell> GenerateFifthDetonationPattern(Cell cell)
        {
            /*
             * the pattern of a mine with the value of 2 is similar to the pattern of a mine with the value of 1
             * so we assign a variable to the method GenerateFourthDetonationPattern
             */
            List<Cell> cellsToDetonate = GenerateFourthDetonationPattern(cell);

            /*
             * then we add the additional Cells 
             */
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X - 2, cell.Y + 2));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y - 2));
            cellsToDetonate.Add(new Cell(cell.X + 2, cell.Y + 2));

            return cellsToDetonate;
        }
    }
}
