using Chaser.Game;
using SFML.Graphics;
using SFML.System;

namespace Chaser.UI.Sprites
{
    public class SpriteFlyweight : Sprite
    {
        public SpriteFlyweight()
        {
        }

        public SpriteFlyweight(Texture texture) : base(texture)
        {
        }

        public SpriteFlyweight(Texture texture, IntRect rectangle) : base(texture, rectangle)
        {
        }

        public SpriteFlyweight(Sprite copy) : base(copy)
        {
        }

        public void Draw(RenderTarget target, GameObjectState objectState)
        {
            this.Position = new Vector2f(objectState.X, objectState.Y);
            Draw(target, RenderStates.Default);
        }
    }
}
