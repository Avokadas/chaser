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

        public RenderingEngine()
        {
            Window = new RenderWindow(new VideoMode(1024,768), "Chaser game");
            _contextSettings = new ContextSettings();

            Window = new RenderWindow(new VideoMode(1024, 768), "Chaser", Styles.Default, _contextSettings);
            Window.Closed += Window_Closed;
            Window.KeyPressed += Window_KeyPressed;
            dogSprite.Position = new Vector2f(100, 100);
            dogSprite.TextureRect = new IntRect(100, 100, 100, 100);
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
                Window.Close();
            }
            if (e.Code == Keyboard.Key.W)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X, oldPos.Y - 10);
            }
            if (e.Code == Keyboard.Key.A)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X - 10, oldPos.Y);
            }
            if (e.Code == Keyboard.Key.S)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X, oldPos.Y + 10);
            }
            if (e.Code == Keyboard.Key.D)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X + 10, oldPos.Y);
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }

        public void RenderGameState()
        {
            Window.DispatchEvents();
            Window.Clear();
            dogSprite.Draw(Window, RenderStates.Default);
            Window.Display();
        }
    }
}
