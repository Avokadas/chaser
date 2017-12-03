using System;
using System.Runtime.Serialization;
using Chaser.Game.Strategies;

namespace Chaser.Game
{
    public class StraightCloseBulletHandler : CloseBulletHandler
    {
        public override void HandleBullet(IBulletMovementStrategy strategy)
        {
            if (strategy is StraightTravelBulletStrategy)
            {
                GameStateSingleton.Instance.State.Player.State.Health -= 5;
            }
            else
            {
                successor?.HandleBullet(strategy);
            }
        }
    }
}