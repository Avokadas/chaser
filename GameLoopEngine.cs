using System.Collections.Generic;
using Chaser.Adapters;

namespace Chaser
{
    public class GameLoopEngine
    {
        private readonly List<ILoopAdapter> _loopAdapters = new List<ILoopAdapter>();

        public void RegisterComponent(ILoopAdapter adapter)
        {
            _loopAdapters.Add(adapter);
        }

        public void Loop()
        {
            _loopAdapters.ForEach(x => x.PerformLoopAction());
        }
    }
}