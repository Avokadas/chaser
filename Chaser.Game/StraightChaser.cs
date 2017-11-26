using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class StraightChaser : Chaser
    {
        protected override MoveCommand GenerateMoveCommand()
        {
            var playerX = GameStateSingleton.Instance.State.Player.State.X;
            var playerY = GameStateSingleton.Instance.State.Player.State.Y;

            var x = GameStateSingleton.Instance.State.Chaser.State.X;
            var y = GameStateSingleton.Instance.State.Chaser.State.Y;

            int deltaX = 0, deltaY = 0;

            var distance = 200;

            if (x - playerX > distance || y - playerY > distance
                || playerX - x > distance || playerY - y > distance)
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

            var command = new MoveCommand(this, deltaX, deltaY);
            return command;
        }
    }
}