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
        public static Specials ConvertCharToSpecials(char character)
        {
            switch (character)
            {
                case '#':
                    return Specials.Hash;
                case '$':
                    return Specials.Dollar;
                case '%':
                    return Specials.Percent;
                case '&':
                    return Specials.Ampersand;
                case '?':
                    return Specials.Question;
                case '@':
                    return Specials.At;
                case '~':
                    return Specials.Tilde;
                case '^':
                    return Specials.Caret;
                case '+':
                    return Specials.Plus;
                case '"':
                    return Specials.Double_Quote;
                case '<':
                    return Specials.Greater;
                case '=':
                    return Specials.Equal;
                case '>':
                    return Specials.Less;
                case '(':
                    return Specials.Open_parenthesis;
                case ')':
                    return Specials.Close_parenthesis;
                case '*':
                    return Specials.Asterisk;
                case '-':
                    return Specials.Minus;
                case '\\':
                    return Specials.Backslash;
                case '_':
                    return Specials.Underscore;
                case '/':
                    return Specials.Forwardslash;
                case ',':
                    return Specials.Comma;
                case '`':
                    return Specials.Acute;
                case '{':
                    return Specials.Open_brace;
                case '}':
                    return Specials.Close_brace;
                case '[':
                    return Specials.Open_bracket;
                case ']':
                    return Specials.Close_bracket;
                case '!':
                    return Specials.Exclamation;
                case '|':
                    return Specials.Pipe;
                case '\'':
                    return Specials.Forwardslash;
                case '.':
                    return Specials.Dot;
                case ':':
                    return Specials.Colon;
                case ';':
                    return Specials.Semicolon;
            }
            return Specials.None;
        }
        public static void Draw(SpriteBatch spriteBatch, Texture2D texture, Rectangle rect, Vector2 position, float? scale)
        {
            spriteBatch.Draw(texture, position, rect, Color.White, 0f, new Vector2(0, 0), scale.Value, SpriteEffects.None, 0f);
        }
    }
}
