using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2DFirstGame.Tiles
{
    public class Level : ILevel
    {
        public List<Tile> Tiles { get; set; }

        private SpriteBatch device;
        private TexturesUtil texturesUtil;

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
            string input;
            using (StreamReader file = new StreamReader(path))
            {
                input = file.ReadToEnd();
            }
            var rows = input.Split(',').ToList();
            int y = 0;
            foreach (var row in rows)
            {
                HandleRow(row, y);
                y += 64;
            }
        }

        private void HandleRow(string row, int y)
        {
            int x = 0;
            foreach (var ch in row)
            {
                switch (ch)
                {
                    case 'L':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Left)));
                        break;
                    case 'R':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Right)));
                        break;
                    case 'U':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Up)));
                        break;
                    case 'D':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Down)));
                        break;
                    case 'j':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Right_Down)));
                        break;
                    case 'q':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Right_Up)));
                        break;
                    case 'l':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Left_Down)));
                        break;
                    case 'p':
                        Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Left_Up)));
                        break;
                    case '_':
                        Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Clear), true));
                        break;
                }
                x += 64;
            }
        }
        /*
         prawy dolny róg - j
prawy górny róg - q
lewy dolny róg - l
lewy górny róg - p
         * */

        public void Draw()
        {
            //todo draw every tile with foreach
        }
    }
}
