using System.Collections.Generic;

namespace _2DFirstGame.Tiles
{
    public interface ILevel
    {
        List<Tile> Tiles { get; set; }

        void ReadLevelFile(string path);
    }
}
