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
        public RenderWindow Window { get; }
        private ContextSettings _contextSettings;
        private static Sprite playerSprite;
        private static Sprite chaserSprite;
        private UserKeys _userInput= new UserKeys();
        
        private List<Sprite> _terrainObjects = new List<Sprite>();
        private ISpriteFactory _spriteFactory;

        public RenderingEngine(ISpriteFactory spriteFactory)
        {
            _spriteFactory = spriteFactory;
            _contextSettings = new ContextSettings();
            Window = new RenderWindow(new VideoMode(1024, 768), "Chaser game", Styles.Default, _contextSettings);
            Window.Closed += Window_Closed;
            Window.KeyPressed += _userInput.KeyPressed;
            Window.KeyReleased += _userInput.KeyReleased;

            chaserSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Chaser);
            playerSprite = _spriteFactory.CreateSprite(GameStateSingleton.Instance.State.Player);

            foreach (var gameObject in GameStateSingleton.Instance.State.Map.TerrainObjects)
            {
                _terrainObjects.Add(_spriteFactory.CreateSprite(gameObject));
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        private void ProcessInput()
        {
            var oldPos = playerSprite.Position;
            var x = oldPos.X;
            var y = oldPos.Y;

            if (_userInput.Close)
            {
                Window.Close();
            }
            if (_userInput.Up)
            {
                y -= 1;
            }
            if (_userInput.Down)
            {
                y += 1;
            }
            if (_userInput.Left)
            {
                x -= 1;
            }
            if (_userInput.Right)
            {
                x += 1;
            }

            playerSprite.Position = new Vector2f(x, y);
        }

        private void Chase() {
            var playerCoodrsX = playerSprite.Position.X;
            var playerCoodrsY = playerSprite.Position.Y;

            var x = chaserSprite.Position.X;
            var y = chaserSprite.Position.Y;

            var distance = 200;

            if (x-playerCoodrsX > distance || y-playerCoodrsY > distance 
                || playerCoodrsX - x > distance || playerCoodrsY - y > distance) {
                if (playerCoodrsX > x)
                {
                    x += 1;
                }
                if (playerCoodrsX < x)
                {
                    x -= 1;
                }
                if (playerCoodrsY > y)
                {
                    y += 1;
                }
                if (playerCoodrsY < y)
                {
                    y -= 1;
                }
            }
            chaserSprite.Position = new Vector2f(x, y);
        }

        public void RenderGameState()
        {
            Window.DispatchEvents();
            ProcessInput();
            Chase();
            Window.Clear();
            playerSprite.Draw(Window, RenderStates.Default);
            chaserSprite.Draw(Window, RenderStates.Default);
            foreach (var sprite in _terrainObjects)
            { 
                sprite.Draw(Window, RenderStates.Default);
            }
            Window.Display();
        }
    }
}
