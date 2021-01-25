using Minefield.GameEngine.Models;

namespace Minefield.GameEngine
{
    public class GameService : IGameService
    {
        public bool Initialized { get; private set; }

        public GameBoard GameBoard { get; private set; }

        public void Start(GameBoardSettings gameBoardSettings)
        {
            if (gameBoardSettings.IsValid)
            {
                GameBoard = new GameBoard(gameBoardSettings.Width, gameBoardSettings.Height);
                Initialized = true;
            }
        }

        public void End()
        {
            Initialized = false;
        }
    }
}