using Minefield.GameEngine.Models;
using System;

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
                GameBoard = new GameBoard(gameBoardSettings.Width, gameBoardSettings.Height, gameBoardSettings.PlayerLives);
                Initialized = true;
            }
        }

        public void End()
        {
            Initialized = false;
        }

        public void MoveUp()
        {
            Move(GameBoard.Player.CurrentXPosition, GameBoard.Player.CurrentYPosition + 1);

            var tileAbove = GetTileAtPosition(GameBoard.Player.CurrentXPosition, GameBoard.Player.CurrentYPosition + 1);
            if (tileAbove == null)
                GameBoard.Player.HasFinished = true;
           
        }

        public void MoveDown()
        {
            Move(GameBoard.Player.CurrentXPosition, GameBoard.Player.CurrentYPosition - 1);
        }

        public void MoveLeft()
        {
            Move(GameBoard.Player.CurrentXPosition - 1, GameBoard.Player.CurrentYPosition);
        }

        public void MoveRight()
        {
            Move(GameBoard.Player.CurrentXPosition + 1, GameBoard.Player.CurrentYPosition);
        }

        private void Move(int x, int y)
        {
            GameBoard.Player.MoveCount++;

            var tileToMoveTo = GetTileAtPosition(x, y);
            if (tileToMoveTo == null)
                return;

            if (tileToMoveTo.IsMined)
            {
                GameBoard.Player.LivesRemaining--;
                return;
            }

            GameBoard.Player.UpdatePosition(tileToMoveTo);
        }

        private Tile GetTileAtPosition(int x, int y)
        {
            try
            {
                return GameBoard.Tiles[x, y];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}