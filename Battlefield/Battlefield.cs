namespace Battlefield
{
    using System;
    using System.Collections.Generic;

    public sealed class Battlefield
    {
        public const int MinFieldSize = 1;
        public const int MaxFieldSize = 10;
        private const double MinBombsPercentage = 0.15;
        private const double MaxBombsPercentage = 0.30;
        
        private static Random rnd = new Random();
        private static Battlefield instance;
        private char[,] field;
        private int fieldSize;

        private Battlefield(int size)
        {
            this.FieldSize = size;
            this.InitField();
            this.InitMines();
        }

        public int DetonatedMines { get; private set; }

        public int FieldSize
        {
            get
            {
                return this.fieldSize;
            }

            private set
            {
                if (value < 0 || 10 < value)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The field size should be in the range [{0} ... {1}].", MinFieldSize, MaxFieldSize),
                        "fieldSize");
                }

                this.fieldSize = value;
            }
        }
        
        public static Battlefield Create(int size)
        {
            return instance ?? (instance = new Battlefield(size));
        }

        /// <summary>
        /// Displays the battle field on the console
        /// </summary>
        public void DisplayField()
        {
            // top side numbers
            Console.Write("{0}", new string(' ', 2));
            for (int i = 0; i < this.FieldSize; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            Console.Write("{0}", new string(' ', 2));
            for (int i = 0; i < 2 * this.FieldSize; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            // top side numbers
            for (int i = 0; i < this.FieldSize; i++)
            {
                // left side numbers
                Console.Write("{0}|", i);
                for (int j = 0; j < this.FieldSize; j++)
                {
                    Console.Write(" {0}", this.field[i, j]);
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        ///  Checks if the Cell is a mine
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        public bool IsCellMine(Cell cell)
        {
            return '1' <= this.field[cell.Y, cell.X] && this.field[cell.Y, cell.X] <= '5';
        }

        /// <summary>
        /// Checks if the battlefield contains a cell with certain coordinates.
        /// </summary>
        /// <param name="cell">An object containing coordinates</param>
        /// <returns>True or False</returns>
        public bool IsCellInRange(Cell cell)
        {
            bool isXCoordinateInRange = 0 <= cell.X && cell.X < this.FieldSize;
            bool isYCoordinateInRange = 0 <= cell.Y && cell.Y < this.FieldSize;

            return isXCoordinateInRange && isYCoordinateInRange;
        }

        /// <summary>
        /// Method that from a detonated cell returns the cells to explode after detonation
        /// </summary>
        /// <param name="cellToDetonate"></param>
        /// <returns>List of cells to explode</returns>
        private List<Cell> CellsToExplode(Cell cellToDetonate)
        {
            List<Cell> cellsToExplode;

            switch (this.field[cellToDetonate.Y, cellToDetonate.X] - '0')
            {
                case 1:
                    cellsToExplode = PatternFactory.GenerateFirstDetonationPattern(cellToDetonate);
                    break;
                case 2:
                    cellsToExplode = PatternFactory.GenerateSecondDetonationPattern(cellToDetonate);
                    break;
                case 3:
                    cellsToExplode = PatternFactory.GenerateThirdDetonationPattern(cellToDetonate);
                    break;
                case 4:
                    cellsToExplode = PatternFactory.GenerateFourthDetonationPattern(cellToDetonate);
                    break;
                case 5:
                    cellsToExplode = PatternFactory.GenerateFifthDetonationPattern(cellToDetonate);
                    break;
                default:
                    throw new ArgumentException("Cell value is invalid.");
            }

            return cellsToExplode;
        }

        /// <summary>
        /// Method that explodes cells from a given detonated cell
        /// </summary>
        /// <param name="detonatedCell">The cell that have benn detonated</param>
        public void DetonateMine(Cell detonatedCell)
        {
            /*
             * We pass the detonated cell to the method cellsToExplode and get the
             * cells that have to explode
             */
            List<Cell> cellsToExplode = this.CellsToExplode(detonatedCell);

            foreach (var cell in cellsToExplode)
            {
                this.DetonateCell(cell);
            }

            this.DetonatedMines++;
        }

        /// <summary>
        /// Gets the number of remaining mines in the battlefield
        /// </summary>
        /// <returns>Count of mines left</returns>
        public int GetRemainingMinesCount()
        {
            int count = 0;

            foreach (var cell in this.field)
            {
                if (cell != 'X' && cell != '-')
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Initializes the battlefield
        /// </summary>
        private void InitField()
        {
            this.field = new char[this.FieldSize, this.FieldSize];

            for (int row = 0; row < this.FieldSize; row++)
            {
                for (int column = 0; column < this.FieldSize; column++)
                {
                    this.field[row, column] = '-';
                }
            }
        }

        /// <summary>
        /// Gets the number of mines that will be placed on the battlefield
        /// </summary>
        /// <returns>A valid number of mines in the specified range.</returns>
        public int GetMinesCount()
        {
            int minesLowerLimit = (int)Math.Floor(MinBombsPercentage * this.FieldSize * this.FieldSize);
            int minesUpperLimit = (int)Math.Floor(MaxBombsPercentage * this.FieldSize * this.FieldSize);

            int minesCount = rnd.Next(minesLowerLimit, minesUpperLimit + 1);

            return minesCount;
        }

        /// <summary>
        /// Initializes the mines on the battlefield
        /// </summary>
        private void InitMines()
        {
            int minesCount = this.GetMinesCount();

            for (int i = 0; i < minesCount; i++)
            {
                bool isMinePlaced = false;

                while (!isMinePlaced)
                {
                    var tempXCoordinate = rnd.Next(0, this.FieldSize - 1);
                    var tempYCoordinate = rnd.Next(0, this.FieldSize - 1);

                    if (this.field[tempXCoordinate, tempYCoordinate] == '-')
                    {
                        this.field[tempXCoordinate, tempYCoordinate] = (char)(rnd.Next(1, 6) + '0');
                    }
                    else
                    {
                        isMinePlaced = true;
                    }
                }
            }
        }

        /// <summary>
        /// Detonates a single cell on the battlefield
        /// </summary>
        /// <param name="cellToDetonate">An object containing the coordinates of the detonated mine</param>
        private void DetonateCell(Cell cellToDetonate)
        {
            if (this.IsCellInRange(cellToDetonate))
            {
                this.field[cellToDetonate.Y, cellToDetonate.X] = 'X';                
            }
        }
    }
}