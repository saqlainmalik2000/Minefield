using Minefield.GameEngine;
using System;

namespace Minefield.ConsoleApp
{
    public class GameManager : IGameManager
    {
        private IGameService _gameService;

        public IGameService MyProperty => _gameService;

        public GameManager()
        {
            _gameService = new GameService();
        }

        public void DisplayHeader()
        {
            Console.Title = "Minefield";
            Console.WriteLine("Welcome to Minefield!");
            Console.WriteLine("Press [Ctr-S] at any time to start a new game");
            Console.WriteLine("Press [Esc] at any time to exit the game");
            Console.WriteLine("The objective of the game is to reach the far end of the board before using up all your lives");
            Console.WriteLine("You can move the player by using the up, down, left, right arrow keys");
        }

        public void StartNewGame()
        {
            _gameService.Start();
            Console.WriteLine("Game started");
        }

        public void ExitGame()
        {
            _gameService.End();
            Environment.Exit(0);
        }
    }
}
