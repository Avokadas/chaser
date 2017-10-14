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
        private static Sprite dogSprite = new Sprite(new Texture("Assets/doge.jpg"));
        private UserKeys userInput= new UserKeys();

        public RenderingEngine()
        {
            Window = new RenderWindow(new VideoMode(1024,768), "Chaser game");
            _contextSettings = new ContextSettings();

            Window = new RenderWindow(new VideoMode(1024, 768), "Chaser", Styles.Default, _contextSettings);
            Window.Closed += Window_Closed;
            Window.KeyPressed += userInput.KeyPressed;
            Window.KeyReleased += userInput.KeyReleased;
            dogSprite.Position = new Vector2f(100, 100);
            dogSprite.TextureRect = new IntRect(100, 100, 100, 100);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        private void ProcessInput()
        {
            var oldPos = dogSprite.Position;
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

            dogSprite.Position = new Vector2f(x, y);
        }

        public void RenderGameState()
        {
            Window.DispatchEvents();
            ProcessInput();
            Window.Clear();
            dogSprite.Draw(Window, RenderStates.Default);
            Window.Display();
        }
    }
}
