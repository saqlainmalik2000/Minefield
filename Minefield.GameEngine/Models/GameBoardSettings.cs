namespace Minefield.GameEngine.Models
{
    public class GameBoardSettings
    {
        // TODO: In a production system these values would be configurable
        private const int MaxWidthAllowed = 20;
        private const int MaxHeightAllowed = 20;
        private const int MaxPlayerLivesAllowed = 5;

        public GameBoardSettings(int width, int height, int playerLives)
        {
            Width = width;
            Height = height;
            PlayerLives = playerLives;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int PlayerLives { get; set; }

        public bool IsValid => CheckIfValid();


        private bool CheckIfValid()
        {
            if ((Width <= 0 || Width > MaxWidthAllowed) || 
                (Height <= 0 || Height > MaxHeightAllowed) || 
                (PlayerLives < 0 || PlayerLives > MaxPlayerLivesAllowed))
                return false;

            return true;
        }
    }
}
