using System;
using Chaser.Game;
using Chaser.Game.TerrainObjects;
using SFML.Graphics;
using SFML.System;

namespace Chaser.UI
{
    public class DefaultSpriteFactory : ISpriteFactory
    {
        public Sprite CreateSprite(GameObject obj)
        {
            if (obj is Bullet)
            {
                var sprite = new Sprite(new Texture("Assets/Bullet.jpg"),
                    new IntRect(obj.Xpic, obj.Ypic, obj.Width, obj.Height));
                sprite.Position = new Vector2f(obj.X, obj.Y);
                return sprite;
            }
            if (obj is Wall)
            {
                var sprite = new Sprite(new Texture("Assets/Wall.jpg"),
                    new IntRect(obj.Xpic, obj.Ypic, obj.Width, obj.Height));
                sprite.Position = new Vector2f(obj.X, obj.Y);
                return sprite;
            }
            if (obj is Player)
            {
                var sprite = new Sprite(new Texture("Assets/player.jpg"),
                    new IntRect(obj.Xpic, obj.Ypic, obj.Width, obj.Height));
                sprite.Position = new Vector2f(obj.X, obj.Y);
                return sprite;
            }
            if (obj is Game.Chaser)
            {
                var sprite = new Sprite(new Texture("Assets/doge.jpg"),
                    new IntRect(obj.Xpic, obj.Ypic, obj.Width, obj.Height));
                sprite.Position = new Vector2f(obj.X, obj.Y);
                return sprite;
            }

            throw new ArgumentException("No sprite defined for the provided object");
        }
    }
}