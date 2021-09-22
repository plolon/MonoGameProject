﻿using _2DFirstGame.DrawingHandler.String.Utils;
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

        private int CurrentX;
        private int CurrentY;

        private const float scale = 2f;
        private const int width = (int)(64 * scale);
        private const int height = (int)(64 * scale);
        private const int modifier = (int)(16 * scale);

        private int maxX;
        private int maxY;

        Random random = new Random();
        public Level(TexturesUtil textureUtil, string path)
        {
            Tiles = new List<Tile>();
            texturesUtil = textureUtil;
            ReadLevelFile(path);
            GetMaxValues();
        }

        private void GetMaxValues()
        {
            Rectangle lastTile = Tiles[Tiles.Count - 1].Rectangle;
            maxX = 0 - (lastTile.X + lastTile.Width - Config.Width);
            maxY = 0 - (lastTile.Y + lastTile.Height - Config.Height);
        }

        public void Draw()
        {
            Logger.Info($"{CurrentX} {CurrentY}", ConsoleColor.Green);
            DrawGround();
            DrawWalls();
        }
        public void Update(Direction direction)
        {
            var tmp = Tiles[Tiles.Count - 1].Rectangle.X + Tiles[Tiles.Count - 1].Rectangle.Width;
            var tmp2 = tmp - 800;
            Logger.Info($"{tmp2}", ConsoleColor.Red);

            switch (direction)
            {
                case Direction.Up:
                    if (CurrentY > maxY)
                        CurrentY -= 2;
                    break;
                case Direction.Down:
                    if (CurrentY < 0)
                        CurrentY += 2;
                    break;
                case Direction.Left:
                    if (CurrentX > maxX)
                        CurrentX -= 2;
                    break;
                case Direction.Right:
                    if (CurrentX < 0)
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
                            meta = GetRandomMeta(new List<Rectangle>()
                            {   texturesUtil.GetSource(Grounds.Flat_1),
                                texturesUtil.GetSource(Grounds.Flat_2),
                                texturesUtil.GetSource(Grounds.Flat_3),
                                texturesUtil.GetSource(Grounds.Flat_4),});
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), meta, true));
                            break;
                        case 'D':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Down), true));
                            break;
                        case 'R':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Right), true));
                            break;
                        case 'L':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Left), true));
                            break;
                        case 'U':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Up), true));
                            break;
                        case 'q':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RU), true));
                            break;
                        case 'j':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RD), true));
                            break;
                        case 'p':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LU), true));
                            break;
                        case 'k':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LD), true));
                            break;
                        case 'Q':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RU2), true));
                            break;
                        case 'J':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RD2), true));
                            break;
                        case 'P':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LU2), true));
                            break;
                        case 'l':
                            Tiles.Add(new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LD2), true));
                            break;
                        case 'w':
                            meta = GetRandomMeta(new List<Rectangle>() { texturesUtil.GetSource(Walls.Wall_1), texturesUtil.GetSource(Walls.Wall_2) });
                            Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), meta));
                            break;
                        case 'W':
                            Tiles.Add(new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Wall_up)));
                            break;
                        case '0':
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
            if(rand == 3)
            {
                rand = random.Next(0, from.Count);
            }
            return from[rand];
        }
    }
}
