using System.Data.Common;
using TikTakToeLib.Interfaces;
using TikTakToeLib.Models;

namespace TikTakToeLib
{
    public class Board : IBoard
    {
        public Cell[,] Grid { get; private set; }
        private int _rows { get; set; } = 3;
        private int _columns { get; set; } = 3;
        public int RequireToWin { get; set; }

        private int _numberOfRowsCells = 3;

        public int NumberOfRowsCells
        {
            get { return _numberOfRowsCells; }
        }

        public Board()
        {
            Grid = new Cell[_rows, _columns];
            ResetBoard();
        }

        public void ResetBoard()
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
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
        public bool isWinningConditionMet(Player player)
        {
            for (int i = 0; i < _numberOfRowsCells; i++)
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

            //int counter = 0;
            //for (int i = 0; i < Rows; i++)
            //{ 
            //    for (int j = 0; j < Columns; j++)
            //    {  
            //        if (Grid[i, j] == player.CellType)
            //        {
            //            counter++;
            //            if (counter == RequireToWin)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //               counter = 0;
            //            }
            //        }
            //    }
            //}
            //counter = 0;
            //for (int i = 0; i < Rows; i++)
            //{
            //    for (int j = 0; j < Columns; j++)
            //    {
            //        if (Grid[j, i] == player.CellType)
            //        {
            //            counter++;
            //            if (counter == RequireToWin)
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                counter = 0;
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < NumberOfRowsCells; i++)
            //{
            //    if (Grid[i, i] == player.CellType)
            //    {
            //        counter++;
            //        if (counter == RequireToWin)
            //        {
            //            return true;
            //        }
            //        else
            //        {
            //            counter = 0;
            //        }
            //    }

        }
    }

}