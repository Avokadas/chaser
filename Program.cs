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
        private static UserInputProcessor _inputProcessor;

        static void Main()
        {
            var window = new RenderWindow(new VideoMode(1024, 768), "Chaser", Styles.Default, new ContextSettings());
            var timer = new Clock();
            _inputProcessor = new UserInputProcessor(new UserInputConfiguration(), window);

            window.KeyPressed += _inputProcessor.UserInputConfiguration.KeyPressed;
            window.KeyReleased += _inputProcessor.UserInputConfiguration.KeyReleased;
            ;

            _renderingEngine = new RenderingEngine(window, new DefaultSpriteFactory());

            while (_renderingEngine.Window.IsOpen)
            {
                _inputProcessor.Process();
                Chase();
                ShootBullet(_renderingEngine, timer);
                _renderingEngine.RenderGameState();
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

        private static void ShootBullet(RenderingEngine renderEngine, Clock timer)
        {
            if (timer.ElapsedTime.AsSeconds() > 2)
            {
                timer.Restart();
                renderEngine.AddBullet(new DefaultSpriteFactory());
            }
        }
    }
}