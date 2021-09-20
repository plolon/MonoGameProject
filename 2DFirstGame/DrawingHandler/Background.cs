using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.DrawingHandler
{
    public class Background
    {
        private Texture2D texture;
        private List<Rectangle> tiles;

        int currentPos;

        public Background(Texture2D texture, int width, int height)
        {
            currentPos = 0;
            this.texture = texture;
            tiles = CreateTiles(width, height, texture.Width, texture.Height);
        }

        public void Move()
        {

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
