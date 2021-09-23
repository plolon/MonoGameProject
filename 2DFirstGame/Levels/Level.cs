using _2DFirstGame.DrawingHandler.String.Utils;
using _2DFirstGame.Levels;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace _2DFirstGame.Tiles
{
    public class Level : ILevel
    {
        public List<Tile> Tiles { get; set; }

        private TexturesUtil texturesUtil;

        private int CurrentX;
        private int CurrentY;

        private const float scale = 1f;
        private const int width = (int)(64 * scale);
        private const int height = (int)(64 * scale);

        private int maxX;
        private int maxY;

        Random random = new Random();
        public Level(TexturesUtil textureUtil, string level)
        {
            Tiles = new List<Tile>();
            texturesUtil = textureUtil;
            ReadLevelFile(level);
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
            
            var levelRows = LevelUtil.GetLevelBasics(path);
            var tiles = LevelUtil.GetLevelInfo(levelRows[0]);
            var decorations = LevelUtil.GetLevelInfo(levelRows[1]);

            int y = 0;
            foreach (var row in tiles)
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
                    Tile buffer = TileHelper.SwitchLetter(texturesUtil, ch, x, y);
                    if (buffer != null)
                    {
                        Tiles.Add(buffer);
                        x += width;
                    }
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
    }
}
