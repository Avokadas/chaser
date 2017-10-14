using System;
using Chaser.Game;
using Chaser.Game.TerrainObjects;
using SFML.Graphics;

namespace Chaser.UI
{
    public class DefaultSpriteFactory : ISpriteFactory
    {
        public Sprite CreateSprite(GameObject obj)
        {
            if (obj is Wall)
            {
                return new Sprite(new Texture("Assets/Wall.jpg"), 
                    new IntRect(obj.X, obj.Y, obj.Width, obj.Height));
            }
            if (obj is Player)
            {
                return new Sprite(new Texture("Assets/player.jpg"),
                    new IntRect(obj.X, obj.Y, obj.Width, obj.Height));
            }
            if (obj is Game.Chaser)
            {
                return new Sprite(new Texture("Assets/doge.jpg"),
                    new IntRect(obj.X, obj.Y, obj.Width, obj.Height));
            }

            throw new ArgumentException("No sprite defined for the provided object");
        }
    }
}