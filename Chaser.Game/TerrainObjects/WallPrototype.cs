namespace Chaser.Game.TerrainObjects
{
    public class WallPrototype : TerrainObject
    {
        public WallPrototype(int x, int y, int xpic, int ypic, int width, int height) :
            base(x, y, xpic, ypic, width, height)
        {
        }

        public WallPrototype Clone()
        {
            return (WallPrototype)this.MemberwiseClone();
        }
    }
}