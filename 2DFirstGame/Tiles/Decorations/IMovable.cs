using _2DFirstGame.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2DFirstGame.Tiles.Decorations
{
    public interface IMovable
    {
        public Direction Direction { get; set; }
        public bool InMove { get; set; }
        public void Move();
    }
}
