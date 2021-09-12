using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DFirstGame.DrawingHandler.String
{
    public static class DrawNumbers
    {
        public static Numbers ConvertIntToNumbers(int number)
        {
            if (number == 0)
            {
                return Numbers.Zero;
            }
            else
            {
                return (Numbers)number - 1;
            }
        }
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle rect, Vector2 position, float? scale)
        {
            spriteBatch.Draw(texture, position, rect, Color.White, 0f, new Vector2(0, 0), scale.Value, SpriteEffects.None, 0f);
        }
    }
}
