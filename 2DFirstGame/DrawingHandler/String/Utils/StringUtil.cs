using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace _2DFirstGame.DrawingHandler.String.Utils
{
    public class StringUtil
    {
        private List<Rectangle> numbers;
        private List<Rectangle> characters;

        public StringUtil()
        {
            numbers = GenerateNumbers();
            characters = GenerateCharacters();
        }

        public Rectangle getRect(Numbers number)
        {
            return numbers[(int)number];
        }
        public Rectangle getRect(Characters character)
        {
            return characters[(int)character];
        }

        private List<Rectangle> GenerateNumbers()
        {
            List<Rectangle> result = new List<Rectangle>();
            result.Add(new Rectangle(0, 0, 45, 90));
            for (int i = 46; i <= 678; i += 79) 
            {
                result.Add(new Rectangle(i, 0, 79, 90));
            }
            return result;
        }
        private List<Rectangle> GenerateCharacters()
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int i = 0; i <= 1942; i += 79)
            {
                if (i == 632)
                {
                    result.Add(new Rectangle(i, 0, 46, 90));
                    i -= 33;
                }
                else
                {
                    result.Add(new Rectangle(i, 0, 79, 90));
                }
            }
            return result;
        }
    }
}
