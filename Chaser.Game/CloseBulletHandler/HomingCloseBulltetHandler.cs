using System;
using Chaser.Game.Strategies;

namespace Chaser.Game
{
    public class HomingCloseBulltetHandler : CloseBulletHandler
    {
        public override void HandleBullet(IBulletMovementStrategy strategy)
        {
            if (strategy is HomingBuletStrategy)
            {
                GameStateSingleton.Instance.State.Player.State.Health -= 10;
            }
            else
            {
                successor?.HandleBullet(strategy);
            }
        }
    }
}