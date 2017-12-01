using System;
using System.Collections.Generic;
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
            var random = new Random();
            var randValue = random.Next(0, 2);

            if (randValue == 1)
            {
                _gameState.Chaser = new StraightChaser {State = {X = 100, Y = 200, Width = 100, Height = 100}};
            }
            else
            {
                _gameState.Chaser = new ParkinsonsChaser {State = {X = 100, Y = 200, Width = 100, Height = 100}};
            }
        }

        public void AddPlayer()
        {
            _gameState.Player = new Player {State = {X = 100, Y = 100, Width = 100, Height = 100}};
        }

        public void InitScore()
        {
            _gameState.Score = 0;
        }

        public void AddGameMap()
        {
            var longWallPrototype = new Wall(0, 0, 0, 0, 500, 100);
            var tallWallPrototype = new Wall(0, 0, 0, 0, 100, 500);
            var squareWallPrototype = new Wall(0, 0, 0, 0, 100, 100);

            const int numberOfWalls = 2;
            var random = new Random();

            TerrainObjectCollection walls = new TerrainObjectCollection();

            //var walls = new List<GameObject>();

            for (var i = 0; i < numberOfWalls; i++)
            {
                Wall wall;
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
                
                wall.State.X = random.Next(200, 500);
                wall.State.Y = random.Next(200, 500);
                /*
                wall.State.X = 300;
                wall.State.Y = 200;*/

                walls[i] = wall;
            }

            _gameState.Map = new GameMap
            {
                TerrainObjects = walls
            };
        }

        public void SetStartGameState()
        {
            _gameState.GameRunning = true;
        }

        public GameState GetGameState()
        {
            return _gameState;
        }
    }

    public class GameMap
    {
        public TerrainObjectCollection TerrainObjects { get; set; }
    }
}