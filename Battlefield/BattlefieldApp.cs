namespace Battlefield
{
    using System;

    public class BattlefieldApp
    {
        public static void Main(string[] args)
        {
            string tempFieldSize;
            int size;
            Console.WriteLine("Welcome to the Battle Field game");

            do
            {
                Console.Write("Enter legal size of board: ");
                tempFieldSize = Console.ReadLine();
            } while ((!int.TryParse(tempFieldSize, out size)) || (size < Battlefield.MinFieldSize) || (size > Battlefield.MaxFieldSize));

            Battlefield battlefield = Battlefield.Create(size);
            battlefield.DisplayField();

            do
            {
                Console.Write("Enter coordinates: ");
                var coordinates = Console.ReadLine().Split();
                var xCoordinate = int.Parse(coordinates[1]);
                var yCoordinate = int.Parse(coordinates[0]);

                Cell cellToExplode = new Cell(xCoordinate, yCoordinate);

                while (!battlefield.IsCellInRange(cellToExplode) || !battlefield.IsCellMine(xCoordinate, yCoordinate))
                {
                    Console.WriteLine("Invalid Move");
                    Console.Write("Enter coordinates: ");
                    coordinates = Console.ReadLine().Split();
                    xCoordinate = int.Parse(coordinates[0]);
                    yCoordinate = int.Parse(coordinates[1]);
                }

                battlefield.DetonateMine(xCoordinate, yCoordinate);
                battlefield.DisplayField();
            } while (battlefield.GetRemainingMinesCount() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + battlefield.DetonatedMines);
            Console.ReadKey();
        }
    }
}
