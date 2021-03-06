﻿using Chaser.Game;

namespace Chaser.Adapters
{
    public class GameStateMutatorAdapter : ILoopAdapter
    {
        private GameState _state = GameStateSingleton.Instance.State;


        public void PerformLoopAction()
        {
            if (GameStateSingleton.Instance.State.GameRunning)
            {
                _state.MutateGameState();
            }
        }
    }
}