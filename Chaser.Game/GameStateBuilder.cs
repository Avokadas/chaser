using System.Runtime.InteropServices;

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
           _gameState.Chaser = new Chaser();
        }

        public void AddPlayer()
        {
            _gameState.Player = new Player();
        }

        public void AddGameMap()
        {
            _gameState.Map = new GameMap();
        }

        public GameState GetGameState()
        {
            return _gameState;
        }
    }

    public class GameMap
    {
    }
}