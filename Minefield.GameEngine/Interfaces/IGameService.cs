using Minefield.GameEngine.Models;

namespace Minefield.GameEngine
{
    public interface IGameService
    {
        bool Initialized { get; }
        GameBoard GameBoard { get; }

        void Start(GameBoardSettings gameBoardSettings);
        void End();
    }
}