﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chaser.Game;
using Chaser.UI.Sprites;
using SFML.Graphics;

namespace Chaser.UI
{
    public interface ISpriteFactory
    {
        SpriteFlyweight CreateSprite(GameObject obj);
    }
}
