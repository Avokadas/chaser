using Chaser.Game.Strategies;

namespace Chaser.Game
{
    public abstract class CloseBulletHandler
    {
        protected CloseBulletHandler successor;

        public void SetSuccessor(CloseBulletHandler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleBullet(IBulletMovementStrategy strategy);
    }
}