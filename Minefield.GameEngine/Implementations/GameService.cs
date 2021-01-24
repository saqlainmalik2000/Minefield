namespace Minefield.GameEngine
{
    public class GameService : IGameService
    {
        private bool _initialized;

        public bool Initialized => _initialized;

        public void Start()
        {
            _initialized = true;
        }

        public void End()
        {
            _initialized = false;
        }
    }
}