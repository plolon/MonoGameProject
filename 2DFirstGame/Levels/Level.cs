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

        private const float scale = 2f;
        private const int width = (int)(64 * scale);
        private const int height = (int)(64 * scale);
        private const int modifier = (int)(16 * scale);
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
            DrawInside_Walls();
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
            int x = 0;
            foreach (var ch in row)
            {
                if (!String.IsNullOrEmpty(ch.ToString()))
                {
                    switch (ch)
                    {
                        case 'L':
                            AddGroundTile(x + modifier, y);
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Left)));
                            break;
                        case 'R':
                            AddGroundTile(x - modifier, y);
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Right)));
                            break;
                        case 'U':
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Up)));
                            break;
                        case 'D':
                            AddGroundTile(x, y - modifier);
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Down)));
                            break;
                        case 'j':
                            AddGroundTile(x - modifier, y - modifier);
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Right_Down)));
                            break;
                        case 'q':
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Right_Up)));
                            break;
                        case 'l':
                            AddGroundTile(x + modifier, y - modifier);
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Left_Down)));
                            break;
                        case 'p':
                            Tiles.Add(new Wall(new Rectangle(x, y, width, height), texturesUtil.GetSource(Walls.Left_Up)));
                            break;
                        case '_':
                            AddGroundTile(x, y);
                            break;
                        case '1':
                            Tiles.Add(new Wall_Inside(new Rectangle(x, y, width, height), texturesUtil.GetSource(Inside_Walls.Right)));
                            break;
                        case '2':
                            Tiles.Add(new Wall_Inside(new Rectangle(x, y, width, height), texturesUtil.GetSource(Inside_Walls.Left)));
                            break;
                        case '3':
                            Tiles.Add(new Wall_Inside(new Rectangle(x, y, width, height), texturesUtil.GetSource(Inside_Walls.Down)));
                            break;
                        case '4':
                            Tiles.Add(new Wall_Inside(new Rectangle(x, y, width, height), texturesUtil.GetSource(Inside_Walls.Up)));
                            break;
                        case '5':
                            Tiles.Add(new Wall_Inside(new Rectangle(x, y, width, height), texturesUtil.GetSource(Inside_Walls.Solid)));
                            break;
                        default:
                            continue;
                    }
                    x += width;
                }
            }
        }
        private void AddGroundTile(int x, int y)
        {
            Tiles.Add(new Ground(new Rectangle(x, y, width, height), texturesUtil.GetSource(Grounds.Clear), true));
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
        private void DrawInside_Walls()
        {
            foreach (var tile in Tiles)
            {
                Vector2 position = new Vector2(tile.Rectangle.X + CurrentX, tile.Rectangle.Y + CurrentY);
                if (tile.GetType().Name.Equals("Wall_Inside"))
                {
                    texturesUtil.Device.Draw(texturesUtil.Inside_wallsT, position, tile.Source, Color.White, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
                }
            }
        }
    }
}
