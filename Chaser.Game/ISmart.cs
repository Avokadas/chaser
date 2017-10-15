using System.Collections.Generic;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public interface ISmart
    {
        List<Command> ReturnNextMove();
    }
}