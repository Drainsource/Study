using System.Data.Common;
using TikTakToeLib.Interfaces;
using TikTakToeLib.Models;

namespace TikTakToeLib
{
    public class Board : IBoard
    {
        public Cell[,] Grid { get; set; }
        public int Rows { get; set; } = 3;
        public int Columns { get; set; } = 3;
        public int RequireToWin { get; set; }
        public int NumberOfRowsCells { get; set; } = 3;

        public Board()
        {
            Grid = new Cell[Rows, Columns];
            ResetBoard();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Grid[i, j] = Cell.Empty;
                }
            }
        }
        public bool Add(int row, int column, Player player)
        {
            if (Grid[row, column] == Cell.Empty)
            {
                Grid[row, column] = player.CellType;
                return true;
            }
            return false;
        }
        public bool doesGameOver(Player player)
        {
            for (int i = 0; i < NumberOfRowsCells; i++)
            {
                if (player.CellType == Grid[i, 0] && Grid[i, 0] == Grid[i, 1] && Grid[i, 1] == Grid[i, 2])
                {
                    return true;
                }
                else if (player.CellType == Grid[0, i] && Grid[0, i] == Grid[1, i] && Grid[1, i] == Grid[2, i])
                {
                    return true;
                }
            }
            if (player.CellType == Grid[0, 0] && Grid[0, 0] == Grid[1, 1] && Grid[1, 1] == Grid[2, 2])
            {
                return true;
            }
            if (player.CellType == Grid[0, 2] && Grid[0, 2] == Grid[1, 1] && Grid[1, 1] == Grid[2, 0])
            {
                return true;
            }
            return false;

        }
    }

}