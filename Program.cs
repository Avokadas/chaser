using Chaser.Game;
using Chaser.UI;
using SFML.Graphics;
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
            _inputProcessor = new UserInputProcessor(new UserInputConfiguration(), window);

            window.KeyPressed += _inputProcessor.UserInputConfiguration.KeyPressed;
            window.KeyReleased += _inputProcessor.UserInputConfiguration.KeyReleased;

            _renderingEngine = new RenderingEngine(window, new DefaultSpriteFactory());

            while (_renderingEngine.Window.IsOpen)
            {
                _inputProcessor.Process();
                GameStateSingleton.Instance.State.MutateGameState();
                _renderingEngine.RenderGameState();
            }
        }
    }
}