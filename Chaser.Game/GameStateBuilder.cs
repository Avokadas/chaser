using System;
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
            var longWallPrototype = new WallPrototype(0, 0, 0, 0, 500, 100);
            var tallWallPrototype = new WallPrototype(0, 0, 0, 0, 100, 500);
            var squareWallPrototype = new WallPrototype(0, 0, 0, 0, 100, 100);

            const int numberOfWalls = 5;
            var random = new Random();

            var walls = new List<GameObject>();

            for (var i = 0; i < numberOfWalls; i++)
            {
                WallPrototype wall;
                switch (random.Next(1, 4))
                {
                    case 1:
                        wall = squareWallPrototype.Clone();
                        break;
                    case 2:
                        wall = longWallPrototype.Clone();
                        break;
                    case 3:
                        wall = tallWallPrototype.Clone();
                        break;
                    default:
                        wall = squareWallPrototype.Clone();
                        break;
                }
                wall.X = random.Next(0, 1000);
                wall.Y = random.Next(0, 1000);

                walls.Add(wall);
            }

            _gameState.Map = new GameMap
            {
                TerrainObjects = walls
            };
        }

        public void AddBullets()
        {
            _gameState.BulletList = new BulletList
            {
                Bullets = new List<GameObject> {
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

    public class BulletList
    {
        public List<GameObject> Bullets { get; set; }
    }
}