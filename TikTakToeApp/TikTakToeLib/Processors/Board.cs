using TikTakToeLib.Interfaces;
using TikTakToeLib.Models;

namespace TikTakToeLib
{
    public class Board : IBoard
    {
        public Cell[,] Grid { get; set; }
        public int Rows { get; private set; } = 10;
        public int Columns { get; private set; } = 10;
        public int RequireToWin { get; set; } = 5;
        public List<Coordinate> WiningStreak { get; private set; } = new List<Coordinate>();

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
        public bool DoesGameOver(Player player)
        {
            List<Coordinate> winningStreakRow = new List<Coordinate>();
            List<Coordinate> winningStreakColumn = new List<Coordinate>();

            for (int i = 0; i < Rows; i++)
            {

                int columnCount = 0;
                int rowCount = 0;
                
                for (int j = 0; j < Columns; j++)
                {
                    if (player.CellType == Grid[i, j])
                    {
                        winningStreakRow.Add(new Coordinate { Row = i, Column = j });
                        columnCount++;
                        if (columnCount >= RequireToWin)
                        {
                            WiningStreak = winningStreakRow;
                            return true;
                        }
                    }
                    else
                    {
                        WiningStreak.Clear();
                        columnCount = 0;
                    }

                    if (player.CellType == Grid[j, i])
                    {
                        winningStreakColumn.Add(new Coordinate { Row = j, Column = i });
                        rowCount++;
                        if (rowCount >= RequireToWin)
                        {
                            WiningStreak = winningStreakColumn;
                            return true;
                        }
                    }
                    else
                    {
                        WiningStreak.Clear();
                        rowCount = 0;
                    }

                   bool diagonal = (CheckDiagonal(player, i, j, 1,1) || 
                                    CheckDiagonal(player,i,j,1,-1));
                    if (diagonal)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        private bool CheckDiagonal(Player player, int startRow, int startCol, int rowIncrement, int colIncrement)
        {
            int count = 0;
            int row = startRow;
            int col = startCol;

            while (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                if (Grid[row, col] == player.CellType)
                {
                    count++;
                    WiningStreak.Add(new Coordinate { Row = row, Column = col });
                    if (count >= RequireToWin)
                    {    
                        return true;
                    }
                }
                else
                {
                    WiningStreak.Clear();
                    count = 0;
                }

                row += rowIncrement;
                col += colIncrement;
            }

            return false;
        }

    }

}