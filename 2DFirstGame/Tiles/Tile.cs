using Microsoft.Xna.Framework;

namespace _2DFirstGame.Tiles
{
    public abstract class Tile
    {
        public Rectangle Rectangle { get; set; }
        public Rectangle Source { get; set; }
        public bool CanWalk { get; set; }

        public Tile(Rectangle rectangle, Rectangle source)
        {
            Rectangle = rectangle;
            Source = source;
        }
    }
}
