namespace Chaser.Game
{
    public class GameObject
    {
        public GameObject(int x, int y, int width, int height, bool isCollidable)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            IsCollidable = isCollidable;
        }

        public GameObject()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsCollidable { get; set; }
    }
}
