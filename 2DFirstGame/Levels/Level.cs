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

        private TexturesUtil texturesUtil;

        private int CurrentX;   // TODO moving tiles with adding current X to drowing
        private int CurrentY;

        private const float scale = 1f;
        private const int width = (int)(64 * scale);
        private const int height = (int)(64 * scale);
        private const int modifier = (int)(16 * scale);
        Random random = new Random();
        public Level(TexturesUtil textureUtil, string path)
        {
            Tiles = new List<Tile>();
            texturesUtil = textureUtil;
            ReadLevelFile(path);
        }

        public void Draw()
        {
            DrawGround();
            DrawWalls();
        }
        public void Update(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    CurrentY -= 2;
                    break;
                case Direction.Down:
                    CurrentY += 2;
                    break;
                case Direction.Left:
                    CurrentX -= 2;
                    break;
                case Direction.Right:
                    CurrentX += 2;
                    break;
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
                y += height;
            }
        }

        private void HandleRow(string row, int y)
        {
            Rectangle meta;
            int x = 0;
            foreach (var ch in row)
            {
                if (!String.IsNullOrEmpty(ch.ToString()))
                {
                    switch (ch)
                    {
                        case '_':
                            meta = GetRandomMeta(new List<Rectangle>(){ texturesUtil.GetSource(Grounds.Flat_1),texturesUtil.GetSource(Grounds.Flat_2)});
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), meta, true));
                            break;
                        case 'l':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_corner_righttup), true));
                            break;
                        case 'p':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_corner_rightdown), true));
                            break;
                        case 'j':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_corner_leftup), true));
                            break;
                        case 'q':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_corner_lefttdown), true));
                            break;
                        case 'u':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_down), true));
                            break;
                        case 'L':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_left), true));
                            break;
                        case 'r':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Up_right), true));
                            break;
                        case 'w':
                            meta = GetRandomMeta(new List<Rectangle>() { texturesUtil.GetSource(Walls.Wall_1), texturesUtil.GetSource(Walls.Wall_2) });
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), meta, true));
                            break;
                        case 'W':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Wall_up), true));
                            break;
                        default:
                            continue;
                    }
                    x += width;
                }
            }
        }

        private void DrawGround()
        {
            foreach (var tile in Tiles)
            {
                Vector2 position = new Vector2(tile.Rectangle.X + CurrentX, tile.Rectangle.Y + CurrentY);
                if (tile.GetType().Name.Equals("Ground"))
                {
                    texturesUtil.Device.Draw(texturesUtil.GroundsT, position, tile.Source, Color.White, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
                }
            }
        }
        private void DrawWalls()
        {
            foreach (var tile in Tiles)
            {
                Vector2 position = new Vector2(tile.Rectangle.X + CurrentX, tile.Rectangle.Y + CurrentY);
                if (tile.GetType().Name.Equals("Wall"))
                {
                    texturesUtil.Device.Draw(texturesUtil.WallsT, position, tile.Source, Color.White, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
                }
            }
        }

        private Rectangle GetRandomMeta(List<Rectangle> from)
        {
            int rand = random.Next(0, from.Count);
            return from[rand];
        }
    }
}
