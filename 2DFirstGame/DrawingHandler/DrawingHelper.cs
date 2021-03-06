using _2DFirstGame.DrawingHandler.String;
using _2DFirstGame.DrawingHandler.String.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2DFirstGame.DrawingHandler
{
    public class DrawingHelper
    {
        private Texture2D numbers;
        private Texture2D characters;
        private Texture2D specials;
        private SpriteBatch device;

        private float posX;
        private float posY;
        public StringUtil Util;
        private float scale;

        public DrawingHelper(SpriteBatch device, Texture2D numbers, Texture2D characters, Texture2D specials)
        {
            this.device = device;
            this.numbers = numbers;
            this.characters = characters;
            this.specials = specials;
            Util = new StringUtil();
        }
        public void DrawString(Vector2 position, string text, float scale)
        {
            posX = position.X;
            posY = position.Y;
            this.scale = scale;
            text.ToList().ForEach(x => HandleLetter(x));
        }

        private void HandleLetter(char character)
        {
            int num;
            if (int.TryParse(character.ToString(), out num))    // number
            {
                Numbers code = String.DrawString.ConvertIntToNumbers(num);
                Rectangle rect = Util.getRect(code);
                String.DrawString.Draw(device, numbers, rect, new Vector2(posX, posY), scale);
                posX += (float)Math.Ceiling((decimal)((rect.Width * scale) + (3 * scale)));
            }
            else if (!character.Equals(' '))  // character
            {
                Rectangle rect;
                if (Char.ToLower(character) < 97 || Char.ToLower(character) > 122)
                {
                    Specials code = String.DrawString.ConvertCharToSpecials(character);
                    rect = Util.getRect(code);
                    String.DrawString.Draw(device, specials, rect, new Vector2(posX, posY), scale);
                }
                else
                {
                    Characters code = String.DrawString.ConvertCharToCharacters(character);
                    rect = Util.getRect(code);
                    String.DrawString.Draw(device, characters, rect, new Vector2(posX, posY), scale);
                }
                posX += (float)Math.Ceiling((decimal)((rect.Width * scale) + (3 * scale)));
            }
            else    // whitespace
            {
                posX += (float)Math.Ceiling((decimal)((47 * scale) + (3 * scale)));
            }
        }
    }
}
