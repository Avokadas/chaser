using System.Linq;
using Chaser.Game.Commands;

namespace Chaser.Game.Strategies
{
    public class HomingBuletStrategy : IBulletMovementStrategy
    {
        public MoveCommand CreateMoveCommand(Bullet bullet)
        {
            var playerX = GameStateSingleton.Instance.State.Player.State.X;
            var playerY = GameStateSingleton.Instance.State.Player.State.Y;

            var x = bullet.State.X;
            var y = bullet.State.Y;

            int deltaX = 0, deltaY = 0;

            if (x - playerX > 0 || y - playerY > 0
                || playerX - x > 0 || playerY - y > 0)
            {
                if (playerX > x)
                {
                    deltaX = 1;
                }
                if (playerX < x)
                {
                    deltaX = -1;
                }
                if (playerY > y)
                {
                    deltaY = 1;
                }
                if (playerY < y)
                {
                    deltaY = -1;
                }
            }

            var command = new MoveCommand(bullet, deltaX, deltaY);
            return command;
        }
    }
}