using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Chaser.Game.TerrainObjects;

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
           _gameState.Chaser = new Chaser { Width = 100, Height = 100 };
        }

        public void AddPlayer()
        {
            _gameState.Player = new Player{Width = 100, Height = 100};
        }

        public void AddGameMap()
        {
            _gameState.Map = new GameMap
            {
                TerrainObjects = new GameObject[]
                {
                    new Wall(200, 300, 500, 200),
                    new Wall(500, 500, 200, 300)
                }
            };
        }

        public GameState GetGameState()
        {
            return _gameState;
        }
    }

    public class GameMap
    {
        public IEnumerable<GameObject> TerrainObjects { get; set; }
    }
}