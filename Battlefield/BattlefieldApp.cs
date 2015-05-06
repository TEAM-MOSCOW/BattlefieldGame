namespace Battlefield
{
    using System;

    public class BattlefieldApp
    {
        public static void Main(string[] args)
        {
            int size = GetBattleFieldSize();
            Battlefield battlefield = Battlefield.Create(size);
            battlefield.DisplayField();

            do
            {
                Cell cellToExplode = GetCellToExplode();

                while (!battlefield.IsCellInRange(cellToExplode) || !battlefield.IsCellMine(cellToExplode))
                {
                    Console.WriteLine("---Invalid Move---");
                    cellToExplode = GetCellToExplode();
                }

                battlefield.DetonateMine(cellToExplode);
                battlefield.DisplayField();
            } while (battlefield.GetRemainingMinesCount() != 0);

            Console.WriteLine("Game Over. Detonated Mines: " + battlefield.DetonatedMines);
            Console.ReadKey();
        }

        public static int GetBattleFieldSize()
        {
            int size;
            string tempFieldSize;
            Console.WriteLine("Welcome to the Battle Field game");

            do
            {
                Console.Write("Enter legal size of board: ");
                tempFieldSize = Console.ReadLine();
            } while ((!int.TryParse(tempFieldSize, out size)) || (size < Battlefield.MinFieldSize) || (size > Battlefield.MaxFieldSize));
            
            return size;
        }

        public static Cell GetCellToExplode()
        {
            int xCoordinate,
                yCoordinate;
            Console.Write("Enter coordinates: ");
            var coordinates = Console.ReadLine().Split();
            
            while (coordinates.Length != 2 || !int.TryParse(coordinates[1], out xCoordinate) || !int.TryParse(coordinates[0], out yCoordinate))
            {
                Console.WriteLine("---Invalid coordinates---");
                Console.Write("Enter coordinates: ");
                coordinates = Console.ReadLine().Split();
            }

            return new Cell(xCoordinate, yCoordinate) ;
        }
    }
}
