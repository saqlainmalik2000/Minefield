using Minefield.GameEngine;
using Minefield.GameEngine.Models;
using System;

namespace Minefield.ConsoleApp
{
    public class GameManager : IGameManager
    {
        private IGameService _gameService;

        public GameManager()
        {
            _gameService = new GameService();
        }

        public void StartNewGame()
        {
            var gameSettings = PromptForSettings();
            _gameService.Start(new GameBoardSettings(gameSettings.BoardWidth, gameSettings.BoardHeight, gameSettings.PlayerLives));
            if (_gameService.Initialized)
                RenderGameBoard();
            else
                DisplayError("The game board could not be initialized with the dimensions or player lives given. Please check and try again");
        }

        public void ExitGame()
        {
            _gameService.End();
        }

        public void DisplayHeader()
        {
            Console.Title = "Minefield";
            Console.WriteLine("");
            Console.WriteLine("Welcome to Minefield!");
            Console.WriteLine("Press [Ctr-S] at any time to start a new game");
            Console.WriteLine("Press [Esc] at any time to exit the game");
            Console.WriteLine("The objective of the game is to reach the far end of the board before using up all your lives");
            Console.WriteLine("You can move the player by using the up, down, left, right arrow keys");
            Console.WriteLine("=============================================================================================");
            Console.WriteLine("");
        }


        /// <summary>
        /// ALERT: there is not validation included in this function. The user should play it safe and enter valid values for now
        /// </summary>
        /// <returns></returns>
        private GameSettings PromptForSettings()
        {
            var gameSettings = new GameSettings();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Please enter board width (for initial review please use a maximum of 20)");
            gameSettings.BoardWidth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter board height (for initial review please use a maximum of 20)");
            gameSettings.BoardHeight = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter player lives (for initial review please use a maximum of 5)");
            gameSettings.PlayerLives = int.Parse(Console.ReadLine());

            Console.ResetColor();

            return gameSettings;
        }

        private void RenderGameBoard()
        {
            Console.Clear();
            DisplayHeader();

            for (int y = _gameService.GameBoard.Height - 1; y >= 0; y--)
            {
                DisplayYAxisLabel((y+1).ToString());
                for (int x = 0; x < _gameService.GameBoard.Width; x++)
                    DrawTile(_gameService.GameBoard.Tiles[x, y].IsMined, _gameService.GameBoard.Player.CurrentPosition == _gameService.GameBoard.Tiles[x,y].Id);

                Console.WriteLine("");
            }

            DisplayXAxisLabel("");
            for (int x = 0; x < _gameService.GameBoard.Width; x++)
                DisplayXAxisLabel(_gameService.GameBoard.Tiles[x, 0].XPositionLabel);

            Console.WriteLine("");
            DisplayPlayerInformation(_gameService.GameBoard.Player);
            Console.WriteLine("");

        }


        private void DisplayYAxisLabel(string label)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(label + " ");
            Console.ResetColor();
        }

        private void DisplayXAxisLabel(string label)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(" " + label + " ");
            Console.ResetColor();
        }

        private void DrawTile(bool isMined, bool playerStandingOnTile)
        {
            if(isMined)
                Console.Write($"[x]");
            else
            {
                if(playerStandingOnTile)
                    DisplayPlayerPosition();
                else
                    Console.Write($"[ ]");
            }

            //var mindedLabel = isMined ? 'x' : ' ';
            //Console.Write($"[{mindedLabel}]");
        }

        private void DisplayPlayerInformation(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Player lives remaining: {player.LivesRemaining}");
            Console.WriteLine($"Player moves made: {player.MoveCount}");
            Console.WriteLine($"Player current position: {player.CurrentPositionLabel}");
            Console.ResetColor();
        }

        private void DisplayPlayerPosition()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"[o]");
            Console.ResetColor();
        }

        private static void DisplayError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
