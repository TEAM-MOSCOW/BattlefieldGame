namespace Battlefield.Interfaces
{
    /// <summary>
    /// Represents an abstraction for Battlefields.
    /// </summary>
    public interface IBattlefield
    {
        /// <summary>
        /// Gets the number of detonated mines on the battlefield.
        /// </summary>
        int DetonatedMines { get; }

        /// <summary>
        /// Gets the field size of a battlefield.
        /// </summary>
        int FieldSize { get; }

        /// <summary>
        /// Displays the battle field on the console
        /// </summary>
        void DisplayField();

        /// <summary>
        /// Method that explodes cells from a given detonated cell
        /// </summary>
        /// <param name="detonatedCell">The cell that have been detonated</param>
        void DetonateMine(Cell detonatedCell);

        /// <summary>
        /// Gets the number of remaining mines in the battlefield
        /// </summary>
        /// <returns>Count of mines left</returns>
        int GetRemainingMinesCount();

        /// <summary>
        /// Gets the number of mines that will be placed on the battlefield
        /// </summary>
        /// <returns>A valid number of mines in the specified range.</returns>
        int GetMinesCount();
    }
}