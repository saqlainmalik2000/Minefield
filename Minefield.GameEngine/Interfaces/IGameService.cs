namespace Minefield.GameEngine
{
    public interface IGameService
    {
        bool Initialized { get; }

        void Start();
        void End();
    }
}