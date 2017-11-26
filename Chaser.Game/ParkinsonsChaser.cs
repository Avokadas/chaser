using System;
using Chaser.Game.Commands;

namespace Chaser.Game
{
    public class ParkinsonsChaser : Chaser
    {
        protected override MoveCommand GenerateMoveCommand()
        {
            var random = new Random();

            int deltaX = random.Next(-1, 2);
            int deltaY= random.Next(-1, 2);

            var command = new MoveCommand(this, deltaX, deltaY);
            return command;
        }
    }
}