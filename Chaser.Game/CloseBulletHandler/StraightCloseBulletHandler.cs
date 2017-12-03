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
                var stunner = new Stunner();
                GameStateSingleton.Instance.State.Player.State.Health -= 5;
                GameStateSingleton.Instance.State.Player.Accept(stunner);
            }
            else
            {
                successor?.HandleBullet(strategy);
            }
        }
    }
}