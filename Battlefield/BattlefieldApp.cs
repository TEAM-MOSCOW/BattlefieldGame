namespace Battlefield
{
    using System;

    public class BattlefieldApp
    {
        public static void Main(string[] args)
        {
            string tempFieldSize;
            Console.WriteLine("Welcome to the Battle Field game");

            do
            {
                Console.Write("Enter legal size of board: ");
                tempFieldSize = Console.ReadLine();
            } while ((!int.TryParse(tempFieldSize, out Battlefield.fieldSize)) || (Battlefield.fieldSize < 0) || (Battlefield.fieldSize > 11));

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

                while (!bf.IsCellInRange(cellToExplode) || (bf.positions[yCoordinate, xCoordinate] == '-') || bf.positions[yCoordinate, xCoordinate] == 'X')
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
