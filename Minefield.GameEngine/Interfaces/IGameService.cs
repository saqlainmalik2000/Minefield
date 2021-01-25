using Minefield.GameEngine.Models;
using System;

namespace Minefield.GameEngine
{
    public interface IGameService
    {
        bool Initialized { get; }
        GameBoard GameBoard { get; }

        void Start(GameBoardSettings gameBoardSettings);
        void End();

        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}