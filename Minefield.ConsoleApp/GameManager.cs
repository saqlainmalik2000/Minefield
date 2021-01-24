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
