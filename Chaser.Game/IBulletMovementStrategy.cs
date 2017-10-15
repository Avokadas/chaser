using Chaser.Game.Commands;

namespace Chaser.Game
{
    public interface IBulletMovementStrategy
    {
        MoveCommand CreateMoveCommand(Bullet bullet);
    }
}