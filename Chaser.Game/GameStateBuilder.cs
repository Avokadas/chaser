namespace Chaser.Game
{
    public class GameStateBuilder : IGameStateBuilder
    {
        private GameState _gameState;

        public GameStateBuilder()
        {
            _gameState = new GameState();
        }

        public void AddChaser()
        {
            
        }

        public void AddPlayer()
        {
            
        }

        public void AddTerrainObjects()
        {
            
        }

        public GameState GetGameState()
        {
            return _gameState;
        }
    }
}