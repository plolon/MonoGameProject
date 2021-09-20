
using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles
{
    public class Wall : Tile
    {
        public Wall(Rectangle source) : base(source)
        {
            CanWalk = false;
        }
    }
}
