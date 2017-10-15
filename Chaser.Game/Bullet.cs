namespace Chaser.Game
{
    public class Bullet : GameObject
    {
        public Bullet()
        {
            X = GameStateSingleton.Instance.State.Chaser.X;
            Y = GameStateSingleton.Instance.State.Chaser.Y;
            Width = 30;
            Height = 30;
            IsCollidable = true;
        }
    }
}
