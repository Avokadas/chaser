namespace Chaser.Game
{
    public class Player : GameObject
    {
        public Player()
        {
            State.X = 100;
            State.Y = 100;
            State.Width = 100;
            State.Height = 100;
            State.Health = 100;
            State.IsCollidable = true;
        }
    }
}
