
using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles
{
    public class Wall : Tile
    {
        public Wall(Rectangle rectangle, Rectangle source) : base(rectangle, source)
        {
            CanWalk = false;
        }
    }
}
