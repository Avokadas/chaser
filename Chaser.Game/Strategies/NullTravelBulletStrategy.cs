using Chaser.Game.Commands;

namespace Chaser.Game.Strategies
{
    public class NullTravelBulletStrategy : IBulletMovementStrategy
    {
        public MoveCommand CreateMoveCommand(Bullet bullet)
        {
            return new MoveCommand(bullet, 0, 0);
        }
    }
}