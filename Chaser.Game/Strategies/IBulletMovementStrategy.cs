using Chaser.Game.Commands;

namespace Chaser.Game.Strategies
{
    public interface IBulletMovementStrategy
    {
        MoveCommand CreateMoveCommand(Bullet bullet);
    }
}