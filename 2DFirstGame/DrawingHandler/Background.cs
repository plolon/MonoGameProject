using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.DrawingHandler
{
    public class Background
    {
        private Texture2D texture;
        private List<Rectangle> tiles;
        public Background(Texture2D texture, int width, int height)
        {
            this.texture = texture;
            tiles = CreateTiles(width, height, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch device)
        {
            foreach(var tile in tiles)
            {
                device.Draw(texture, tile, Color.White);
            }
        }

        private List<Rectangle> CreateTiles(int _width, int _height, int width, int height)
        {
            List<Rectangle> result = new List<Rectangle>();
            int rows = _width / width;
            int columns = _height / height;
            for (int i = 0; i < rows; i += width)
            {
                for (int j = 0; j < columns; j += height)
                {
                    result.Add(new Rectangle(i, j, width, height));
                }
            }
            return result;
        }
    }
}
