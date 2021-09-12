﻿using _2DFirstGame.DrawingHandler.String;
using _2DFirstGame.DrawingHandler.String.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;

namespace _2DFirstGame.DrawingHandler
{
    public class DrawingHelper
    {
        private Texture2D numbers;
        private Texture2D characters;
        private SpriteBatch device;

        private float posX;
        private float posY;
        private StringUtil util;
        private float scale;

        public DrawingHelper(SpriteBatch device, Texture2D numbers, Texture2D characters)
        {
            this.device = device;
            this.numbers = numbers;
            this.characters = characters;
            util = new StringUtil();
        }
        public void DrawString(Vector2 position, string text, float scale)
        {
            posX = position.X;
            posX = position.Y;
            this.scale = scale;
            text.ToList().ForEach(x => HandleLetter(x));
        }

        private void HandleLetter(char character)
        {
            int num;
            if (int.TryParse(character.ToString(), out num))    // number
            {
                Numbers code = String.DrawString.ConvertIntToNumbers(num);
                Rectangle rect = util.getRect(code);
                String.DrawString.Draw(device, numbers, rect, new Vector2(posX, posY), scale);
                posX += (float)Math.Ceiling((decimal)((rect.Width * scale) + (3 * scale)));
            }
            else if (character.Equals(' '))  // character
            {
                Characters code = String.DrawString.ConvertCharToCharacters(character);
                Rectangle rect = util.getRect(code);
                String.DrawString.Draw(device, numbers, rect, new Vector2(posX, posY), scale);
                posX += (float)Math.Ceiling((decimal)((rect.Width * scale) + (3 * scale)));
            }
            else    // whitespace
            {
                posX += (float)Math.Ceiling((decimal)((47 * scale) + (3 * scale)));
            }
        }
    }
}
