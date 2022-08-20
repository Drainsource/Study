using TikTakToeLib.Models;

namespace TikTakToeLib.Interfaces;

public interface IBoard
{
    Cell[,] Grid { get; set; }
    int Rows { get; set; }
    int Columns { get; set; }
    int RequireToWin { get; set; }

    public int NumberOfRowsCells { get; set; }

    public void ResetBoard();
    public bool Add(int row, int column, Player player);
    public bool doesGameOver(Player player);

}
