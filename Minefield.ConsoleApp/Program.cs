using Microsoft.Extensions.DependencyInjection;
using Minefield.GameEngine;

namespace Minefield.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameManager().StartNewGame();
        }
    }
}
