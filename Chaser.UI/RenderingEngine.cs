using System;
using System.Collections.Generic;
using Chaser.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser.UI
{
    public class RenderingEngine
    {
        public RenderWindow window { get; set; }
        private static Sprite _playerSprite;
        private static Sprite _chaserSprite;
        private List<Sprite> _terrainObjects = new List<Sprite>();
        private ISpriteFactory _spriteFactory;

        public RenderingEngine(RenderWindow window, ISpriteFactory spriteFactory)
        {
            _spriteFactory = spriteFactory;
            this.window = window;

            _chaserSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Chaser);
            _playerSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Player);

            foreach (var gameObject in GameStateSingleton.Instance.State.Map.TerrainObjects)
            {
                _terrainObjects.Add(_spriteFactory.CreateSprite(gameObject));
            }
        }

        public void RenderGameState()
        {
            _playerSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Player.X,
                GameStateSingleton.Instance.State.Player.Y);
            _chaserSprite.Position = new Vector2f(
                GameStateSingleton.Instance.State.Chaser.X,
                GameStateSingleton.Instance.State.Chaser.Y);

            window.DispatchEvents();
            window.Clear();
            _playerSprite.Draw(window, RenderStates.Default);
            _chaserSprite.Draw(window, RenderStates.Default);

            foreach (var sprite in _terrainObjects)
            {
                sprite.Draw(window, RenderStates.Default);
            }
            window.Display();
        }
    }
}
