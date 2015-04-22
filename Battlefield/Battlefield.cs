namespace Battlefield
{
    using System;

    public class Battlefield
    {
        public static int fieldSize = 0;
        public int detonatedMines = 0;
        public char[,] positions = new char[fieldSize, fieldSize];

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
                positions[cellToDetonate.Y, cellToDetonate.X] = 'X';
            }
        }

        public bool IsCellInRange(Cell cell)
        {
            bool isXCoordinateInRange = 0 <= cell.X && cell.X < fieldSize;
            bool isYCoordinateInRange = 0 <= cell.Y && cell.Y < fieldSize;

            return isXCoordinateInRange && isYCoordinateInRange;
        }

        public void DetonateMine(int xCoordinate, int yCoordinate)
        {
            Cell[] cellsToDetonate;

            switch (this.positions[yCoordinate, xCoordinate] - '0')
            {
                case 1:
                    cellsToDetonate = PatternFactory.GenerateFirstDetonationPattern(xCoordinate, yCoordinate);
                    break;
                case 2:
                    cellsToDetonate = PatternFactory.GenerateSecondDetonationPattern(xCoordinate, yCoordinate);
                    break;
                case 3:
                    cellsToDetonate = PatternFactory.GenerateThirdDetonationPattern(xCoordinate, yCoordinate);
                    break;
                case 4:
                    cellsToDetonate = PatternFactory.GenerateFourthDetonationPattern(xCoordinate, yCoordinate);
                    break;
                case 5:
                    cellsToDetonate = PatternFactory.GenerateFifthDetonationPattern(xCoordinate, yCoordinate);
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
    }
}