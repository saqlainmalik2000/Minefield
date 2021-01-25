using System;

namespace Minefield.GameEngine.Models
{
    public class Player
    {
        public Player(int playerLives, string currentPosition, int currentXPosition, int currentYPosition, string currentPositionLabel)
        {
            LivesRemaining = playerLives;
            CurrentPositionId = currentPosition;
            CurrentXPosition = currentXPosition;
            CurrentYPosition = currentYPosition;
            CurrentPositionLabel = currentPositionLabel;
            MoveCount = 0;
        }

        public int LivesRemaining { get; set; }
        public string CurrentPositionId { get; set; }
        public int CurrentXPosition { get; set; }
        public int CurrentYPosition { get; set; }

        public string CurrentPositionLabel { get; set; }
        public int MoveCount { get; set; }
        public bool HasFinished { get; internal set; }

        internal void UpdatePosition(Tile tileToMoveTo)
        {
            CurrentPositionId = tileToMoveTo.Id;
            CurrentXPosition = tileToMoveTo.XPosition;
            CurrentYPosition = tileToMoveTo.YPosition;
            CurrentPositionLabel = tileToMoveTo.XPositionLabel + tileToMoveTo.YPositionLabel;
        }
    }
}
