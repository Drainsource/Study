using TikTakToeLib.Models;

namespace TikTakToeLib.Interfaces;

public interface IBoard
{

    Cell[,] Grid { get; set; }
    int Rows { get; }
    int Columns { get; }
    int RequireToWin { get; set; }
    public void ResetBoard();
    public bool Add(int row, int column, Player player);
    public List<Coordinate> WiningStreak { get; }
    public bool DoesGameOver(Player player);

}
