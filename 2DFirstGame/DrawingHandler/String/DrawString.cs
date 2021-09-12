using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace _2DFirstGame.DrawingHandler.String
{
    public static class DrawString
    {
        public static Characters ConvertCharToCharacters(char character)
        {
            char ch = Char.ToLower(character);
            int code = (int)ch - 97;
            if (code < 0 || code > 122)
            {
                throw new Exception("TODO: handle special characters");
            }
            else
            {
                if (code == 0)
                {
                    return Characters.Z;
                }
                return (Characters)code;
            }
        }
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
