using BattleShipLiteLibrary;
using BattleShipLiteLibrary.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        WelcomeMessage();
        PlayerInfoModel activePlayer = CreatePlayer("Player 1");
        PlayerInfoModel opponent = CreatePlayer("Player 2");
        PlayerInfoModel winner = null;

        do
        {
            DisplayShotGrid(activePlayer);

            RecordPlayerShot(activePlayer, opponent);

            bool doesGameContinue = GameLogic.PlayersStillActive(opponent);

            if (doesGameContinue)
            {
                (activePlayer, opponent) = (opponent, activePlayer);
            }
            else
            {
                winner = activePlayer;

            }

        } while (winner == null);

        IdentifyWinner(winner);

        Console.ReadLine();
    }

    private static void IdentifyWinner(PlayerInfoModel winner)
    {
        Console.WriteLine($"Congratulations to {winner.UserName } for winning");
        Console.WriteLine($"{ winner.UserName } took { GameLogic.GetShotCount(winner) } shoots.");
    }

    private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponent)
    {
        bool isVallidShot = false;
        string row = "";
        int column = 0;

        do
        {
            string shot = AskForShot(activePlayer);
            try
            {
                (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                isVallidShot = GameLogic.ValidateShot(row, column, activePlayer);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                isVallidShot = false;
            }
            if (isVallidShot == false)
            {
                Console.WriteLine("Invalid shot location please try again.");
            }

        } while (isVallidShot == false);

        bool isAHit = GameLogic.IndentifyShotResult(opponent, row, column);

        GameLogic.MarkShotResult(activePlayer, row, column, isAHit);

        DisplayShotResults(row, column, isAHit);
    }

    private static void DisplayShotResults(string row, int column, bool isAHit)
    {
        if (isAHit)
        {
            Console.WriteLine($"{row}{column} is a Hit!");
        }
        else
        {
            Console.WriteLine($"{row}{column} is a Miss.");
        }
        Console.WriteLine();
    }

    private static string AskForShot(PlayerInfoModel activePlayer)
    {
        
        Console.Write($"{ activePlayer.UserName }, please enter your shot selection: ");
        string output = Console.ReadLine();
        return output;
    }

    private static void DisplayShotGrid(PlayerInfoModel activePlayer)
    {

            string currentRow = activePlayer.ShotGrid[0].SpotLetter;

            foreach (var gridSpot in activePlayer.ShotGrid)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($" {gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }
                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.Write(" X  ");
                }
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
    }

    private static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to Battleship Lite");
        Console.WriteLine("created by Mate Toth");
    }

    private static PlayerInfoModel CreatePlayer(string playerTitle)
    {
        PlayerInfoModel output = new();

        Console.WriteLine($"Player information for { playerTitle }");

        output.UserName = AskForUsersName();

        GameLogic.InitializeGrid(output);

        PlaceShpis(output);

        Console.Clear();

        return output;
    }

    private static string AskForUsersName()
    {
        Console.Write("What is your name: ");
        string? output = Console.ReadLine();
        return output;
    }

    private static void PlaceShpis(PlayerInfoModel model)
    {
        do
        {
            Console.WriteLine($"Where do you want to place ship number { model.ShipLocations.Count + 1 }:");
            string location = Console.ReadLine();

            bool isValidLocation = false;

            try
            {
                isValidLocation = GameLogic.PlaceShip(model, location);
            }
            catch (Exception ex )
            {

                Console.WriteLine("Error: "+ ex.Message);
                isValidLocation = false;
            }

            if (isValidLocation == false)
            {
                Console.WriteLine("That was not a valid location. Please try again.");
            }

        } while (model.ShipLocations.Count < 5);
    }
}