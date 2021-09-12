using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
    }
}
