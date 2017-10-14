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

                _renderingEngine.RenderGameState();
            }
        }
    }
}