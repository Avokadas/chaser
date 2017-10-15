using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class StraightTravelBulletStrategy : IBulletMovementStrategy
    {
        public MoveCommand CreateMoveCommand(Bullet bullet)
        {
            int x = 0;
            int y = 0;

            if (bullet.Direction == Directions.Left)
            {
                x = -1;
            }
            if (bullet.Direction == Directions.Right)
            {
                x = 1;
            }
            if (bullet.Direction == Directions.Up)
            {
                y = 1;
            }
            if (bullet.Direction == Directions.Down)
            {
                y = -1;
            }
            if (bullet.Direction == Directions.UpLeft)
            {
                x = -1;
                y = 1;
            }
            if (bullet.Direction == Directions.UpRight)
            {
                x = 1;
                y = 1;
            }
            if (bullet.Direction == Directions.DownLeft)
            {
                x = -1;
                y = -1;
            }
            if (bullet.Direction == Directions.DownRight)
            {
                x = 1;
                y = -1;
            }

            var command = new MoveCommand(bullet, x, y);
            return command;
        }
    }
}