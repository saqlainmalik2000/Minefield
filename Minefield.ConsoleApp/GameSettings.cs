namespace Minefield.ConsoleApp
{
    public class GameSettings
    {
        public int BoardWidth { get; set; }
        public int BoardHeight { get; set; }
        public int PlayerLives { get; internal set; }
    }
}
