using System.Windows.Forms;

namespace Chaser.Game
{
    public class GameStateSingleton
    {
        private static GameStateSingleton _instance;

        private GameStateSingleton()
        {
            IGameStateBuilder builder = new GameStateBuilder();
            builder.AddChaser();
            builder.InitScore();
            builder.AddPlayer();
            builder.AddGameMap();
            builder.SetStartGameState();
            State = builder.GetGameState();
        }

        public static GameStateSingleton Instance => _instance ?? (_instance = new GameStateSingleton());

        public GameState State { get; private set; }

        public GameSave SavedState { get; private set; }

        public void CreateSave()
        {
            SavedState = new GameSave(State);
        }

        public void LoadSave()
        {
            State.Chaser.State = SavedState.ChaserState;
            State.Player.State = SavedState.PlayerState;
            State.Score = SavedState.Score;
        }
    }
}
