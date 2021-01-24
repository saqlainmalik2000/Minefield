using Minefield.GameEngine;
using System;

namespace Minefield.ConsoleApp
{
    class Program
    {
        static IGameManager _gameManager;

        static void Main(string[] args)
        {

            _gameManager = new GameManager();

            Console.Title = "Minefield";
            Console.WriteLine("Welcome to Minefield!");
            Console.WriteLine("Press [Ctr-S] at any time to start a new game");
            Console.WriteLine("Press [Esc] at any time to exit the game");

            while(1 == 1)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    _gameManager.ExitGame();

                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.S)
                    _gameManager.StartNewGame();
                else
                    Console.WriteLine("Incorrect entry. Please try again");
            }
            
        }

    }
}
