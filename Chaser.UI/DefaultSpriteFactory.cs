using System;
using System.Collections.Generic;
using Chaser.Game;
using Chaser.Game.TerrainObjects;
using Chaser.UI.Sprites;
using SFML.Graphics;
using SFML.System;

namespace Chaser.UI
{
    public class DefaultSpriteFactory : ISpriteFactory
    {
        private readonly Dictionary<Type, SpriteFlyweight> _spriteFlyweights = new Dictionary<Type, SpriteFlyweight>();

        public SpriteFlyweight CreateSprite(GameObject obj)
        {
            var state = obj.State;

            var type = obj.GetType();
            if (_spriteFlyweights.ContainsKey(type))
            {
                return _spriteFlyweights[type];
            }


            if (obj is Bullet)
            {
                var sprite = new SpriteFlyweight(new Texture("Assets/Bullet.jpg"),
                    new IntRect(state.Xpic, state.Ypic, state.Width, state.Height));
                
                _spriteFlyweights.Add(typeof(Bullet), sprite);

                return sprite;
            }
            if (obj is Wall)
            {
                var sprite = new SpriteFlyweight(new Texture("Assets/Wall.jpg"),
                    new IntRect(state.Xpic, state.Ypic, state.Width, state.Height));

                _spriteFlyweights.Add(typeof(Wall), sprite);

                return sprite;
            }
            if (obj is Player)
            {
                var sprite = new SpriteFlyweight(new Texture("Assets/player.jpg"),
                    new IntRect(state.Xpic, state.Ypic, state.Width, state.Height));

                _spriteFlyweights.Add(typeof(Player), sprite);

                return sprite;
            }
            if (obj is Game.Chaser)
            {
                var sprite = new SpriteFlyweight(new Texture("Assets/doge.jpg"),
                    new IntRect(state.Xpic, state.Ypic, state.Width, state.Height));

                _spriteFlyweights.Add(typeof(Game.Chaser), sprite);

                return sprite;
            }

            throw new ArgumentException("No sprite defined for the provided object");
        }
    }
}