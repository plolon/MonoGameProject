using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles.Decorations
{
    public class Crate : Decoration, IMovable
    {
        public Direction Direction { get; set; }
        public bool InMove { get; set; }

        public Crate(Rectangle rectangle, Rectangle source) : base(rectangle, source)
        {
        }

        public void Move()
        {
            //TODO moving but first create player
        }
    }
}
