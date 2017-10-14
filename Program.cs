using System;
using Chaser.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Chaser
{
    class Program
    {
        private static RenderingEngine _renderingEngine = new RenderingEngine();

        static void Main()
        {
            while (_renderingEngine.Window.IsOpen)
            {
                _renderingEngine.RenderGameState();
            }
        }
    }
}