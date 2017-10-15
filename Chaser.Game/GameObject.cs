namespace Chaser.Game
{
    public class GameObject
    {
        public GameObject(int x, int y, int xpic, int ypic, int width, int height, bool isCollidable)
        {
            //position
            X = x;
            Y = y;

            //picture x y
            Xpic = xpic;
            Ypic = ypic;
            Width = width;
            Height = height;
            IsCollidable = isCollidable;
        }

        public GameObject()
        {
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Xpic { get; set; }
        public int Ypic { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsCollidable { get; set; }
    }
}
