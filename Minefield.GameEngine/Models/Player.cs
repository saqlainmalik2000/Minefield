namespace Minefield.GameEngine.Models
{
    public class Player
    {
        public Player(int playerLives, string currentPosition, string currentPositionLabel)
        {
            LivesRemaining = playerLives;
            CurrentPosition = currentPosition;
            CurrentPositionLabel = currentPositionLabel;
            MoveCount = 0;
        }

        public int LivesRemaining { get; set; }
        public string CurrentPosition { get; set; }
        public string CurrentPositionLabel { get; set; }
        public int MoveCount { get; set; }
    }
}
