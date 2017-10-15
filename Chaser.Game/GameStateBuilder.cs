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
           _gameState.Chaser = new Chaser { X = 100, Y = 200, Width = 100, Height = 100 };
        }

        public void AddPlayer()
        {
            _gameState.Player = new Player{ X = 100, Y = 100, Width = 100, Height = 100 };
        }

        public void AddGameMap()
        {
            _gameState.Map = new GameMap
            {
                TerrainObjects = new GameObject[]
                {
                    new Wall(200, 300, 0, 0, 500, 200),
                    new Wall(500, 500, 0, 0, 200, 300)
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