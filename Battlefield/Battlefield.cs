namespace Battlefield
{
    using System;

    public class Battlefield
    {
        public static int fieldSize = 0;
        public int detonatedMines = 0;
        private char[,] positions = new char[fieldSize, fieldSize];

        public Battlefield()
        {
        }

        public void InitField()
        {
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    this.positions[i, j] = '-';
                }
            }
        }

        public void DisplayField()
        {
            // top side numbers
            Console.Write("{0}", new string(' ', 2));
            for (int i = 0; i < fieldSize; i++)
            {
                Console.Write(" {0}", i);
            }

            Console.WriteLine();

            Console.Write("{0}", new string(' ', 2));
            for (int i = 0; i < 2 * fieldSize; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            // top side numbers
            for (int i = 0; i < fieldSize; i++)
            {
                // left side numbers
                Console.Write("{0}|", i);
                for (int j = 0; j < fieldSize; j++)
                {
                    Console.Write(" {0}", this.positions[i, j]);
                }

                Console.WriteLine();
            }
        }

        public void InitMines()
        {
            int minesDownLimit = Convert.ToInt32(0.15 * fieldSize * fieldSize);
            int minesUpperLimit = Convert.ToInt32(0.30 * fieldSize * fieldSize);
            int tempMineXCoordinate;
            int tempMineYCoordinate;
            bool flag = true;
            Random rnd = new Random();

            int minesCount = Convert.ToInt32(rnd.Next(minesDownLimit, minesUpperLimit));
            int[,] minesPositions = new int[minesCount, minesCount];
            Console.WriteLine("mines count is: " + minesCount);

            for (int i = 0; i < minesCount; i++)
            {
                do
                {
                    tempMineXCoordinate = Convert.ToInt32(rnd.Next(0, fieldSize - 1));
                    tempMineYCoordinate = Convert.ToInt32(rnd.Next(0, fieldSize - 1));

                    if (this.positions[tempMineXCoordinate, tempMineYCoordinate] == '-')
                    {
                        this.positions[tempMineXCoordinate, tempMineYCoordinate] = (char)(rnd.Next(1, 6) + '0');
                    }
                    else
                    {
                        flag = false;
                    }
                } while (flag);
            }
        }

        public void DetonateCell(Cell cellToDetonate)
        {
            if (IsCellInRange(cellToDetonate))
            {
                positions[cellToDetonate.YCoordinate, cellToDetonate.XCoordinate] = 'X';
            }
        }

        public static bool IsCellInRange(Cell cell)
        {
            bool isXCoordinateInRange = 0 <= cell.XCoordinate && cell.XCoordinate < fieldSize;
            bool isYCoordinateInRange = 0 <= cell.YCoordinate && cell.YCoordinate < fieldSize;

            return isXCoordinateInRange && isYCoordinateInRange;
        }

        public struct Cell
        {
            public Cell(int xCoordinate, int yCoordinate)
                : this()
            {
                this.XCoordinate = xCoordinate;
                this.YCoordinate = yCoordinate;
            }

            public int XCoordinate { get; private set; }

            public int YCoordinate { get; private set; }
        }

        public Cell[] GetDetonatedCells1(int xCoordinate, int yCoordinate)
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

        public Cell[] GetDetonatedCells2(int xCoordinate, int yCoordinate)
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

        public Cell[] GetDetonatedCells3(int xCoordinate, int yCoordinate)
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

        public Cell[] GetDetonatedCells4(int xCoordinate, int yCoordinate)
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

        public Cell[] GetDetonatedCells5(int xCoordinate, int yCoordinate)
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

        public void DetonateMine(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate;

            switch (this.positions[yCoordinate, xCoordinate] - '0')
            {
                case 1:
                    cellsToDetonate = GetDetonatedCells1(xCoordinate, yCoordinate);
                    break;
                case 2:
                    cellsToDetonate = GetDetonatedCells2(xCoordinate, yCoordinate);
                    break;
                case 3:
                    cellsToDetonate = GetDetonatedCells3(xCoordinate, yCoordinate);
                    break;
                case 4:
                    cellsToDetonate = GetDetonatedCells4(xCoordinate, yCoordinate);
                    break;
                case 5:
                    cellsToDetonate = GetDetonatedCells5(xCoordinate, yCoordinate);
                    break;
                default:
                    throw new Exception();
            }

            foreach (var cell in cellsToDetonate)
            {
                DetonateCell(cell);
            }
        }

        public int GetRemainingMinesCount()
        {
            int count = 0;

            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; i < fieldSize; i++)
                {
                    if ((this.positions[i, j] != 'X') && (this.positions[i, j] != '-'))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static void Main(string[] args)
        {
            string tempFieldSize;
            Console.WriteLine("Welcome to the Battle Field game");

            do
            {
                Console.Write("Enter legal size of board: ");
                tempFieldSize = Console.ReadLine();
            } while ((!int.TryParse(tempFieldSize, out fieldSize)) || (fieldSize < 0) || (fieldSize > 11));

            Battlefield bf = new Battlefield();
            bf.InitField();
            bf.InitMines();
            bf.DisplayField();

            do
            {
                Console.Write("Enter coordinates: ");
                var coordinates = Console.ReadLine().Split();
                var xCoordinate = int.Parse(coordinates[1]);
                var yCoordinate = int.Parse(coordinates[0]);

                Cell cellToExplode = new Cell(xCoordinate, yCoordinate);

                while (!IsCellInRange(cellToExplode) || (bf.positions[yCoordinate, xCoordinate] == '-') || bf.positions[yCoordinate, xCoordinate] == 'X')
                {
                    Console.WriteLine("Invalid Move");
                    Console.Write("Enter coordinates: ");
                    coordinates = Console.ReadLine().Split();
                    xCoordinate = int.Parse(coordinates[0]);
                    yCoordinate = int.Parse(coordinates[1]);
                }

                bf.DetonateMine(xCoordinate, yCoordinate);
                bf.DisplayField();
                bf.detonatedMines++;
            } while (bf.GetRemainingMinesCount() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + bf.detonatedMines);
            Console.ReadKey();
        }
    }
}