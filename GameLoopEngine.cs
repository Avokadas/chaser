using System.Collections.Generic;
using Chaser.Adapters;

namespace Chaser
{
    public class GameLoopEngine
    {
        private readonly List<ILoopAdapter> _loopAdapers = new List<ILoopAdapter>();

        public void RegisterComponent(ILoopAdapter adapter)
        {
            _loopAdapers.Add(adapter);
        }

        public void Loop()
        {
            _loopAdapers.ForEach(x => x.PerformLoopAction());
        }
    }
}