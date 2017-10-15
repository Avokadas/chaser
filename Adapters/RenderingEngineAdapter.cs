using Chaser.UI;

namespace Chaser.Adapters
{
    public class RenderingEngineAdapter : ILoopAdapter
    {
        private RenderingEngine _renderingEngine;

        public RenderingEngineAdapter(RenderingEngine renderingEngine)
        {
            _renderingEngine = renderingEngine;
        }

        public void PerformLoopAction()
        {
            _renderingEngine.RenderGameState();
        }
    }
}