using _2DFirstGame.Utils;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace _2DFirstGame.Tiles
{
    public class Level : ILevel
    {
        public List<Tile> Tiles { get; set; }   // create this from "tiles"
        private List<char> tiles;
        private SpriteBatch device;

        private int CurrentX;
        private int CurrentY;

        public Level(SpriteBatch device, string path)
        {
            this.device = device;
            ReadLevelFile(path);
        }

        public void Update(Direction direction)
        {
            switch (direction)
            {
                // move every tiles
            }
        }

        public void ReadLevelFile(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                // TODO create level tiles from txt file
            }
        }

        public void Draw()
        {
            //todo draw every tile with foreach
        }
    }
}
