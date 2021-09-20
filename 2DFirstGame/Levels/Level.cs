using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2DFirstGame.Tiles
{
    public class Level : ILevel
    {
        public List<Tile> Tiles { get; set; }
        private Texture2D walls;
        private Texture2D grounds;

        private SpriteBatch device;
        private TexturesUtil texturesUtil;

        private int CurrentX;   // TODO moving tiles with adding current X to drowing
        private int CurrentY;

        public Level(SpriteBatch device, string path, Texture2D walls, Texture2D grounds)
        {
            Tiles = new List<Tile>();
            texturesUtil = new TexturesUtil();
            this.walls = walls; // TODO something better to contain textures
            this.grounds = grounds; // TODO something better to contain textures
            this.device = device;
            ReadLevelFile(path);
        }

        public void Draw()
        {
            foreach (var tile in Tiles)
            {
                Vector2 position = new Vector2(tile.Rectangle.X, tile.Rectangle.Y);
                if (tile.GetType().Name.Equals("Wall"))
                {
                    device.Draw(walls, position, tile.Source, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                }
                else if (tile.GetType().Name.Equals("Ground"))
                {
                    device.Draw(grounds, position, tile.Source, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
                }
            }
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
                file.Close();
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
                if (!String.IsNullOrEmpty(ch.ToString()))
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
                        default:
                            continue;
                    }
                    x += 64;
                }
            }
        }
    }
}
