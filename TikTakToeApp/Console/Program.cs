using TikTakToeLib;
using TikTakToeLib.Models;



Console.Write("Player 1. enter your name: ");
string player1Name = Console.ReadLine();
Player player1 = new(player1Name, Cell.X);

Console.Write("Player 2. enter your name: ");
string player2Name = Console.ReadLine();
Player player2 = new(player2Name, Cell.O);

Board board = new Board();
Player player = player1;

bool isVaible = false;
bool isWinning = false;
do
{
    do
    {
        Console.Write($"{player.Name} enter your cell number (row,column):");
        string coordinate = Console.ReadLine();
        var grid = coordinate.Split(',');
        int.TryParse(grid[0], out int row);
        int.TryParse(grid[1], out int column);
        isVaible = board.Add(row, column, player);
    } while (!isVaible);

    isWinning = board.isWinningConditionMet(player);
    if (isWinning)
    {
        Console.WriteLine($"{player.Name} win!");
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



