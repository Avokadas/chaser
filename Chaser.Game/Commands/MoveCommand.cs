namespace Chaser.Game.Commands
{
    public class MoveCommand : Command
    {
        private readonly int _xDiff;
        private readonly int _yDiff;
        private GameObject _gameObject;

        public MoveCommand(GameObject gameObject, int xDiff, int yDiff)
        {
            _xDiff = xDiff;
            _yDiff = yDiff;
            _gameObject = gameObject;
        }

        public override void Execute()
        {
            _gameObject.X += _xDiff;
            _gameObject.Y += _yDiff;
        }
    }
}