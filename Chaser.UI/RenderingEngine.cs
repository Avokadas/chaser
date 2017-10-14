using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser.UI
{
    public class RenderingEngine
    {
        public RenderWindow Window { get; }
        private ContextSettings _contextSettings;
        private static Sprite playerSprite = new Sprite(new Texture("Assets/player.jpg"));
        private static Sprite chaserSprite = new Sprite(new Texture("Assets/doge.jpg"));
        private UserKeys userInput= new UserKeys();
        

        public RenderingEngine()
        {
            _contextSettings = new ContextSettings();
            Window = new RenderWindow(new VideoMode(1024, 768), "Chaser game", Styles.Default, _contextSettings);
            Window.Closed += Window_Closed;
            Window.KeyPressed += userInput.KeyPressed;
            Window.KeyReleased += userInput.KeyReleased;
            playerSprite.Position = new Vector2f(100, 100);
            playerSprite.TextureRect = new IntRect(100, 100, 100, 100);
            
            chaserSprite.Position = new Vector2f(500, 400);
            chaserSprite.TextureRect = new IntRect(100, 100, 100, 100);

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

            if (userInput.Close)
            {
                Window.Close();
            }
            if (userInput.Up)
            {
                y -= 1;
            }
            if (userInput.Down)
            {
                y += 1;
            }
            if (userInput.Left)
            {
                x -= 1;
            }
            if (userInput.Right)
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
            Window.Display();
        }
    }
}
