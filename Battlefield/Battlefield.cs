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
        
        public void DetonateMine1(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }
        }

        public void DetonateMine2(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord, YCoord - 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 1, YCoord] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 1, YCoord] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord, YCoord + 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 1] = 'X';
            }
        }

        public void DetonateMine3(int XCoord, int YCoord)
        {
            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 2, YCoord] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 1, YCoord] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 1, YCoord] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 2, YCoord] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord, YCoord - 2] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord, YCoord + 2] = 'X';
            }
        }

        public void DetonateMine4(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord, YCoord - 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 1, YCoord] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 1, YCoord] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord, YCoord + 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 2] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord, YCoord + 2] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 2] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 2] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord, YCoord - 2] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 2] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord - 1] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 2, YCoord] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord + 1] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord - 1] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 2, YCoord] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord + 1] = 'X';
            }
        }

        public void GrymniPetaBomba(int XCoord, int YCoord)
        {
            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord, YCoord - 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 1, YCoord] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord, YCoord] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 1, YCoord] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 1] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord, YCoord + 1] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 1] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord + 2] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord, YCoord + 2] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord + 2] = 'X';
            }

            if ((XCoord - 1 >= 0) && (XCoord - 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord - 1, YCoord - 2] = 'X';
            }

            if ((XCoord >= 0) && (XCoord < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord, YCoord - 2] = 'X';
            }

            if ((XCoord + 1 >= 0) && (XCoord + 1 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord + 1, YCoord - 2] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord - 1] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord - 2, YCoord] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord + 1] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 1 >= 0) && (YCoord - 1 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord - 1] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord >= 0) && (YCoord < fieldSize))
            {
                this.positions[XCoord + 2, YCoord] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 1 >= 0) && (YCoord + 1 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord + 1] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord - 2] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord - 2 >= 0) && (YCoord - 2 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord - 2] = 'X';
            }

            if ((XCoord - 2 >= 0) && (XCoord - 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord - 2, YCoord + 2] = 'X';
            }

            if ((XCoord + 2 >= 0) && (XCoord + 2 < fieldSize) && (YCoord + 2 >= 0) && (YCoord + 2 < fieldSize))
            {
                this.positions[XCoord + 2, YCoord + 2] = 'X';
            }
        }
        
        public void DetonateMine(int XCoord, int YCoord)
        {
            switch (this.positions[XCoord, YCoord] - '0')
            {
                case 1: 
                    this.DetonateMine1(XCoord, YCoord);
                    break;
                case 2: 
                    this.DetonateMine2(XCoord, YCoord);
                    break;
                case 3: 
                    this.DetonateMine3(XCoord, YCoord);
                    break;
                case 4: 
                    this.DetonateMine4(XCoord, YCoord);
                    break;
                case 5: 
                    this.GrymniPetaBomba(XCoord, YCoord);
                    break;
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

            string[] coordinates;
            int XCoord, YCoord;

            do
            {
                do
                {
                    Console.Write("Enter coordinates: ");
                    coordinates = Console.ReadLine().Split();
                    XCoord = int.Parse(coordinates[0]);
                    YCoord = int.Parse(coordinates[1]);

                    if ((XCoord < 0) || (YCoord > fieldSize - 1) || (bf.positions[XCoord, YCoord] == '-'))
                    {
                        Console.WriteLine("Invalid Move");
                    }
                } while ((XCoord < 0) || (YCoord > fieldSize - 1) || (bf.positions[XCoord, YCoord] == '-'));

                bf.DetonateMine(XCoord, YCoord);
                bf.DisplayField();
                bf.detonatedMines++;
            } while (bf.GetRemainingMinesCount() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + bf.detonatedMines);
            Console.ReadKey();
        }
    }
}