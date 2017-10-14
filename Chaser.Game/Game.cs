using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaser.Game
{

    public class GameStateSingleton
    {
        private static GameStateSingleton _instance;

        private GameStateSingleton()
        {
        }

        public static GameStateSingleton Instance => _instance ?? (_instance = new GameStateSingleton());

    }
}
