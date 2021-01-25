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
            _gameService.Start(new GameBoardSettings { Width = gameSettings.BoardWidth, Height = gameSettings.BoardHeight });
            if (_gameService.Initialized)
                RenderGameBoard();
            else
                DisplayError("The game board could not be initialized with the dimensions given. Please check and try again");          
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

            Console.WriteLine("Please enter board width");
            gameSettings.BoardWidth = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter board height");
            gameSettings.BoardHeight = int.Parse(Console.ReadLine());

            Console.ResetColor();

            return gameSettings;
        }

        private void RenderGameBoard()
        {
            Console.Clear();
            DisplayHeader();

            for (int y = _gameService.GameBoard.Height - 1; y >= 0; y--)
            {
                DisplayYAxisLabel(y.ToString());
                for (int x = 0; x < _gameService.GameBoard.Width; x++)
                    DrawTile(_gameService.GameBoard.Tiles[x, y].IsMined);

                Console.WriteLine("");
            }

            DisplayXAxisLabel("");
            for (int x = 0; x < _gameService.GameBoard.Width; x++)
                DisplayXAxisLabel(_gameService.GameBoard.Tiles[x, 0].XPositionLabel);

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

        private void DrawTile(bool isMined)
        {
            var mindedLabel = isMined ? 'x' : ' ';
            Console.Write($"[{mindedLabel}]");
        }

        private static void DisplayError(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
