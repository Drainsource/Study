using TikTakToeLib;
using TikTakToeLib.Models;
using System;


internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.Write("Player 1. enter your name: ");
        string player1Name = System.Console.ReadLine();
        Player player1 = new(player1Name, Cell.X);

        System.Console.Write("Player 2. enter your name: ");
        string player2Name = System.Console.ReadLine();
        Player player2 = new(player2Name, Cell.O);

        Board board = new Board();
        Player player = player1;

        bool isVaible;
        bool isWinning;
        do
        {
            do
            {
                System.Console.Write($"{player.Name} enter your cell number (row,column):");
                string coordinate = System.Console.ReadLine();
                var grid = coordinate.Split(',');
                int.TryParse(grid[0], out int row);
                int.TryParse(grid[1], out int column);
                isVaible = board.Add(row, column, player);
            } while (!isVaible);

            isWinning = board.doesGameOver(player);
            if (isWinning)
            {
                System.Console.WriteLine($"{player.Name} win!");
            }
            else
            {
                if (player == player1)
                {
                    player = player2;
                }
                else
                {
                    player = player1;
                }
            }
        } while (!isWinning);
    }
}