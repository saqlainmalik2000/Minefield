using Minefield.GameEngine;
using Minefield.GameEngine.Models;
using System;

namespace Minefield.ConsoleApp
{
    public class GameManager : IGameManager
    {
        // TODO: in a production system this should be configurable
        private const int MaxBoardWidthAllowed = 20;
        private const int MaxBoardHeightAllowed = 20;
        private const int MaxPlayerLivesAllowed = 5;
        private const bool DisplayMines = true;

        private const string BoardCouldNotBeInitializedMessage = "The game board could not be initialized with the dimensions or player lives given. Please check and try again";

        private IGameService _gameService;

        public GameManager()
        {
            _gameService = new GameService();
        }

        public void StartNewGame()
        {
            DisplayHeader();
            Start();

            while (_gameService.GameBoard.Player.LivesRemaining != 0 && !_gameService.GameBoard.Player.HasFinished)
            {
                var input = Console.ReadKey(true);

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        _gameService.MoveUp();
                        RenderGameBoard();
                        break;

                    case ConsoleKey.DownArrow:
                        _gameService.MoveDown();
                        RenderGameBoard();
                        break;

                    case ConsoleKey.LeftArrow:
                        _gameService.MoveLeft();
                        RenderGameBoard();
                        break;

                    case ConsoleKey.RightArrow:
                        _gameService.MoveRight();
                        RenderGameBoard();
                        break;

                    case ConsoleKey.Enter:
                        Start();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        return;
                }
            }

            if (_gameService.GameBoard.Player.HasFinished)
                DisplayGameWonMessage();

            if (_gameService.GameBoard.Player.LivesRemaining == 0)
                DisplayGameLostMessage();

            Console.ReadKey();
        }


        private void Start()
        {
            var gameSettings = PromptForSettings();
            _gameService.Start(new GameBoardSettings(gameSettings.BoardWidth, gameSettings.BoardHeight, gameSettings.PlayerLives));
            if (_gameService.Initialized)
                RenderGameBoard();
            else
                DisplayError(BoardCouldNotBeInitializedMessage);
        }

        private void DisplayHeader()
        {
            Console.Title = "Minefield";
            Console.WriteLine("");
            Console.WriteLine("Welcome to Minefield!");
            Console.WriteLine("Press [Enter] at any time to start a new game");
            Console.WriteLine("Press [Esc] at any time to exit the game");
            Console.WriteLine("The objective of the game is to reach the far end of the board before using up all your lives");
            Console.WriteLine("You can move the player by using the up, down, left, right arrow keys");
            Console.WriteLine("=============================================================================================");
            Console.WriteLine("");
        }


        private GameSettings PromptForSettings()
        {
            var gameSettings = new GameSettings();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            gameSettings.BoardWidth = PromptForIntValue($"Please enter board width (for initial review please use a maximum of {MaxBoardWidthAllowed}): ", MaxBoardWidthAllowed);
            gameSettings.BoardHeight = PromptForIntValue($"Please enter board height (for initial review please use a maximum of {MaxBoardHeightAllowed}): ", MaxBoardHeightAllowed);
            gameSettings.PlayerLives = PromptForIntValue($"Please enter player lives (for initial review please use a maximum of {MaxPlayerLivesAllowed}): ", MaxPlayerLivesAllowed);

            Console.ResetColor();

            return gameSettings;
        }

        private int PromptForIntValue(string message, int maxValue)
        {
            Console.Write(message);
            int value = 0;
            while (value == 0)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int parsedValue))
                {
                    if (parsedValue > maxValue)
                        DisplayError($"Please enter a value up to {maxValue}");
                    else if (parsedValue == 0)
                        DisplayError($"Please enter a number between 1 and {maxValue}");
                    else
                        value = parsedValue;
                }
                else
                {
                    DisplayError($"Please enter a number between 1 and {maxValue}");
                }
            }
            Console.WriteLine("");
            return value;
        }

        private void RenderGameBoard()
        {
            Console.Clear();
            DisplayHeader();

            // display the Y-axis for each row, along with the tiles which belong to that row
            for (int y = _gameService.GameBoard.Height - 1; y >= 0; y--)
            {
                DisplayYAxisLabel((y+1).ToString());
                for (int x = 0; x < _gameService.GameBoard.Width; x++)
                    DrawTile(_gameService.GameBoard.Tiles[x, y].IsMined, _gameService.GameBoard.Player.CurrentPositionId == _gameService.GameBoard.Tiles[x,y].Id);

                Console.WriteLine("");
            }

            DisplayXAxisLabel();
            Console.WriteLine("");
            DisplayPlayerInformation(_gameService.GameBoard.Player);
            Console.WriteLine("");

        }

        private void DisplayYAxisLabel(string label)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(label.PadLeft(2) + " ");
            Console.ResetColor();
        }

        private void DisplayXAxisLabel()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(string.Empty.PadRight(4));
            
            for (int x = 0; x < _gameService.GameBoard.Width; x++)
                Console.Write(_gameService.GameBoard.Tiles[x, 0].XPositionLabel.PadRight(3));

            Console.ResetColor();
        }

        private void DrawTile(bool isMined, bool playerStandingOnTile)
        {
            if(isMined && DisplayMines)
                Console.Write($"[x]");
            else
            {
                if(playerStandingOnTile)
                    DisplayPlayerPosition();
                else
                    Console.Write($"[ ]");
            }
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

        private static void DisplayGameLostMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Either the board cannot be navigated, or you lost all your lives");
            Console.ResetColor();
        }

        private static void DisplayGameWonMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Congratulations, you won!");
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
