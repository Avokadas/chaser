namespace Chaser.Game.Commands
{
    public class MoveCommand : Command
    {
        public readonly int XDiff;
        public readonly int YDiff;
        private GameObject _gameObject;

        public MoveCommand(GameObject gameObject, int xDiff, int yDiff)
        {
            XDiff = xDiff;
            YDiff = yDiff;
            _gameObject = gameObject;
        }

        public override void Execute()
        {
            _gameObject.State.X += XDiff;
            _gameObject.State.Y += YDiff;
        }
    }
}