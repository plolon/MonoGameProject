using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.DrawingHandler
{
    public class Background
    {
        private Texture2D texture;
        private List<Rectangle> tiles;

        int currentXPos;
        int currentYPos;

        public Background(Texture2D texture, int width, int height)
        {
            currentXPos = 0;
            currentYPos = 0;
            this.texture = texture;
            tiles = CreateTiles(width, height, texture.Width, texture.Height);
        }

        public void Move(Direction direction)
        {
            switchDirection(direction);
            if(currentXPos == 64 || currentXPos == -64)
            {
                currentXPos = 0;
            }
            if (currentYPos == 64 || currentYPos == -64)
            {
                currentYPos = 0;
            }
        }

        private void switchDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    currentYPos -= 2;
                    break;
                case Direction.Down:
                    currentYPos += 2;
                    break;
                case Direction.Right:
                    currentXPos += 2;
                    break;
                case Direction.Left:
                    currentXPos -= 2;
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch device)
        {
            foreach(var tile in tiles)
            {
                Rectangle rect = new Rectangle(tile.X + currentXPos, tile.Y + currentYPos, tile.Width, tile.Height);
                device.Draw(texture, rect, Color.White);
            }
        }

        private List<Rectangle> CreateTiles(int _width, int _height, int width, int height)
        {
            List<Rectangle> result = new List<Rectangle>();
            int rows = _width / width;
            int columns = _height / height;
            for (int i = -width; i <_width + width; i += width)
            {
                for (int j = -width; j <= _height + height; j += height)
                {
                    result.Add(new Rectangle(i, j, width, height));
                }
            }
            return result;
        }
    }
}
