using System;
using System.ComponentModel.Design;
using Chaser.Game;
using Chaser.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser
{
    class Program
    {
        private static RenderingEngine _renderingEngine;
        private static UserInput userInput;

        static void Main()
        {
            var window = new RenderWindow(new VideoMode(1024, 768), "Chaser", Styles.Default, new ContextSettings());

            userInput = new UserInput(window);

            window.KeyPressed += userInput.KeyPressed;
            window.KeyReleased += userInput.KeyReleased;

            _renderingEngine = new RenderingEngine(window);

            while (_renderingEngine.window.IsOpen)
            {
                ProcessInput(window);
                Chase();

                _renderingEngine.RenderGameState();
            }
        }

        private static void ProcessInput(RenderWindow window)
        {
            if (userInput.Close)
            {
                window.Close();
            }
            if (userInput.Up)
            {
                GameStateSingleton.Instance.State.Player.Y -= 1;
            }
            if (userInput.Down)
            {
                GameStateSingleton.Instance.State.Player.Y += 1;
            }
            if (userInput.Left)
            {
                GameStateSingleton.Instance.State.Player.X -= 1;
            }
            if (userInput.Right)
            {
                GameStateSingleton.Instance.State.Player.X += 1;
            }
        }

        private static void Chase()
        {
            var playerX = GameStateSingleton.Instance.State.Player.X;
            var playerY = GameStateSingleton.Instance.State.Player.Y;

            var x = GameStateSingleton.Instance.State.Chaser.X;
            var y = GameStateSingleton.Instance.State.Chaser.Y;

            var distance = 200;

            if (x - playerX > distance || y - playerY > distance
                || playerX - x > distance || playerY - y > distance)
            {
                if (playerX > x)
                {
                    x += 1;
                }
                if (playerX < x)
                {
                    x -= 1;
                }
                if (playerY > y)
                {
                    y += 1;
                }
                if (playerY < y)
                {
                    y -= 1;
                }
            }
            GameStateSingleton.Instance.State.Chaser.X = x;
            GameStateSingleton.Instance.State.Chaser.Y = y;
        }
    }
}