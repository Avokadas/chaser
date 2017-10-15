using Chaser.Adapters;
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
            _renderingEngine = new RenderingEngine(window, new DefaultSpriteFactory());

            var loopEngine = new GameLoopEngine();
            loopEngine.RegisterComponent(new UserInputProcessorAdapter(_inputProcessor));
            loopEngine.RegisterComponent(new GameStateMutatorAdapter());
            loopEngine.RegisterComponent(new RenderingEngineAdapter(_renderingEngine));

            while (_renderingEngine.Window.IsOpen)
            {
               loopEngine.Loop();
            }
        }
    }
}