using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles
{
    public class Ground : Tile
    {
        public Ground(Rectangle rectangle, Rectangle source, bool canWalk) : base(rectangle, source)
        {
            CanWalk = canWalk;
        }
    }
}
