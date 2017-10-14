using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser
{
    class Program
    {
        private static ContextSettings _context = new ContextSettings();
        private static RenderWindow _window;
        private static Sprite dogSprite = new Sprite(new Texture("Assets/doge.jpg"));

        static void Main()
        {
            _window = new RenderWindow(new VideoMode(1024, 768), "Chaser", Styles.Default, _context);
            _window.Closed += Window_Closed;
            _window.KeyPressed += Window_KeyPressed;
            dogSprite.Position = new Vector2f(100, 100);
            dogSprite.TextureRect = new IntRect(100,100,100,100);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear();
                dogSprite.Draw(_window, RenderStates.Default);
                _window.Display();
            }
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.Escape)
            {
               _window.Close();
            }
            if (e.Code == Keyboard.Key.W)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X, oldPos.Y + 10);
            }
            if (e.Code == Keyboard.Key.A)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X - 10, oldPos.Y);
            }
            if (e.Code == Keyboard.Key.S)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X, oldPos.Y - 10);
            }
            if (e.Code == Keyboard.Key.D)
            {
                var oldPos = dogSprite.Position;
                dogSprite.Position = new Vector2f(oldPos.X + 10, oldPos.Y);
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}