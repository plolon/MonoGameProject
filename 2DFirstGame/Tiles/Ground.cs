using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles
{
    public class Ground : Tile
    {
        public Ground(Rectangle source, bool canWalk) : base(source)
        {
            CanWalk = canWalk;
        }
    }
}
