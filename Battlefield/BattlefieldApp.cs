namespace Battlefield
{
    using System;
    using Interfaces;

    /// <summary>
    /// Main class for the program
    /// </summary>
    public class BattlefieldApp
    {
        /// <summary>
        /// Main method for the game
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to the Battle Field game");

            int size = GetBattleFieldSize();
            IBattlefield battlefield = Battlefield.Create(size);
            battlefield.DisplayField();

            while (battlefield.GetRemainingMinesCount() != 0)
            {
                Cell cellToExplode = GetCellToExplode();

                while (!battlefield.IsCellInRange(cellToExplode) || !battlefield.IsCellMine(cellToExplode))
                {
                    Console.WriteLine("---Invalid Move---");
                    cellToExplode = GetCellToExplode();
                }

                battlefield.DetonateMine(cellToExplode);
                battlefield.DisplayField();
            }

            Console.WriteLine("Game Over. Detonated Mines: " + battlefield.DetonatedMines);
            Console.ReadKey();
        }

        /// <summary>
        /// A method which reads input from the console in order to set the battlefield size
        /// </summary>
        /// <returns>The size of the battlefield entered by the user.</returns>
        public static int GetBattleFieldSize()
        {
            int size;

            Console.Write("Enter legal size of board: ");
            var tempFieldSize = Console.ReadLine();

            while ((!int.TryParse(tempFieldSize, out size))
                    || (size < Battlefield.MinFieldSize)
                    || (size > Battlefield.MaxFieldSize))
            {
                Console.Write("Enter legal size of board: ");
                tempFieldSize = Console.ReadLine();
            }

            return size;
        }

        /// <summary>
        /// A method which reads user input in order to create a cell object which should be detonated.
        /// </summary>
        /// <returns>A cell object which should be detonated.</returns>
        public static Cell GetCellToExplode()
        {
            int xCoordinate;
            int yCoordinate;

            Console.Write("Enter coordinates: ");
            var coordinates = Console.ReadLine().Split();

            while (coordinates.Length != 2 
                || !int.TryParse(coordinates[1], out xCoordinate) 
                || !int.TryParse(coordinates[0], out yCoordinate))
            {
                Console.WriteLine("---Invalid coordinates---");
                Console.Write("Enter coordinates: ");
                coordinates = Console.ReadLine().Split();
            }

            return new Cell(xCoordinate, yCoordinate);
        }
    }
}
