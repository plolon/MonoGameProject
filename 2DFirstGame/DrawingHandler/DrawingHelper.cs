using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace _2DFirstGame.DrawingHandler
{
    public class DrawingHelper
    {
        private Texture2D numbers;
        private Texture2D characters;

        public DrawingHelper(Texture2D numbers, Texture2D characters)
        {
            this.numbers = numbers;
            this.characters = characters;
        }

        public void DrawString(SpriteBatch device, Vector2 position, string text, float scale)
        {
            text.ToList().ForEach(x => HandleLetter(x));

            void HandleLetter(char letter)
            {
                int num;
                if(int.TryParse(letter.ToString(), out num))    // number
                {

                }
                else if (true)  // character
                {

                }
                else    // whitespace
                {

                }
            }

        }
    }
}
