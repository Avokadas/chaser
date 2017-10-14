namespace Chaser.Game
{
    public class GameStateSingleton
    {
        private static GameStateSingleton _instance;

        private GameStateSingleton()
        {
        }

        public static GameStateSingleton Instance => _instance ?? (_instance = new GameStateSingleton());

        public GameState State { get; set; }
    }

    public class GameState
    {
        //TODO: All stuff that gets rendered goes here
    }
}
