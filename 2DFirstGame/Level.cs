using System.Collections.Generic;
using System.IO;

namespace _2DFirstGame.Tiles
{
    public class Level : ILevel
    {
        public List<Tile> Tiles { get; set; }   // create this from "tiles"
        private List<char> tiles;   

        public Level(string path)
        {
            ReadLevelFile(path);
        }

        public void ReadLevelFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                // TODO create level tiles from txt file
            }
        }
    }
}
