using System.Collections.Generic;
using System.Linq;
using Chaser.Game;
using SFML.Graphics;
using SFML.System;
using System;
using Chaser.Game.Strategies;

namespace Chaser.UI
{
    public class RenderingEngine
    {
        public RenderWindow Window { get; }
        private static Sprite _playerSprite;
        private static Sprite _chaserSprite;
        private List<Sprite> _terrainObjects = new List<Sprite>();
        private List<GameObjectState> _bulletStates = new List<GameObjectState>();
        private ISpriteFactory _spriteFactory;

        public RenderingEngine()
        {
        }

        public RenderingEngine(RenderWindow window, ISpriteFactory spriteFactory)
        {
            _spriteFactory = spriteFactory;
            Window = window;

            _chaserSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Chaser);
            _playerSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Player);

            foreach (var gameObject in GameStateSingleton.Instance.State.Map.TerrainObjects)
            {
                _terrainObjects.Add(_spriteFactory.CreateSprite(gameObject));
            }
        }

        public virtual void RenderGameState()
        {
            //Next 2 lines might be shit performance
            _bulletStates.Clear();
            GameStateSingleton.Instance.State.Bullets.ForEach(x => _bulletStates.Add(x.State));
            
            Window.DispatchEvents();
            Window.Clear();

            if (GameStateSingleton.Instance.State.Player != null)
            {
                _playerSprite.Position = new Vector2f(
                    GameStateSingleton.Instance.State.Player.State.X,
                    GameStateSingleton.Instance.State.Player.State.Y);

                _playerSprite.Draw(Window, RenderStates.Default);
            }

            if (GameStateSingleton.Instance.State.Chaser != null)
            {
                _chaserSprite.Position = new Vector2f(
                    GameStateSingleton.Instance.State.Chaser.State.X,
                    GameStateSingleton.Instance.State.Chaser.State.Y);

                _chaserSprite.Draw(Window, RenderStates.Default);
            }

            if (GameStateSingleton.Instance.State.Map.TerrainObjects.Count() != 0)
            {
                foreach (var sprite in _terrainObjects)
                {
                    sprite.Draw(Window, RenderStates.Default);
                }
            }

            var bulletSprite = _spriteFactory.CreateSprite(new Bullet(Directions.Down, new HomingBuletStrategy()));
            foreach (var state in _bulletStates)
            {
                bulletSprite.Draw(Window, state);
            }
            Window.Display();
        }
    }
}
