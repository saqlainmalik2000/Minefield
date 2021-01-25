namespace Minefield.GameEngine.Models
{
    public class GameBoardSettings
    {
        // TODO: In a production system these values would be configurable
        private const int MaxWidthAllowed = 20;
        private const int MaxHeightAllowed = 20;

        public GameBoardSettings()
        {
            Width = 5;
            Height = 5;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsValid => CheckIfValid();


        private bool CheckIfValid()
        {
            if ((Width <= 0 || Width > MaxWidthAllowed) || (Height <= 0 || Height > MaxHeightAllowed))
                return false;

            return true;
        }
    }
}
