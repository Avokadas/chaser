using System.Data.SqlClient;

namespace Chaser.Game
{
    public class GameStateSingleton
    {
        private static GameStateSingleton _instance;

        private GameStateSingleton()
        {
            IGameStateBuilder builder = new GameStateBuilder();
            builder.AddChaser();
            builder.AddPlayer();
            builder.AddTerrainObjects();
            State = builder.GetGameState();
        }

        public static GameStateSingleton Instance => _instance ?? (_instance = new GameStateSingleton());

        public GameState State { get; set; }
    }
}
