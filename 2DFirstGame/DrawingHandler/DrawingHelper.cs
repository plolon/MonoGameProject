using _2DFirstGame.DrawingHandler.String;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Numerics;

namespace _2DFirstGame.DrawingHandler
{
    public class DrawingHelper
    {
        private Texture2D numbers;
        private Texture2D characters;

        private float posX;

        public DrawingHelper(Texture2D numbers, Texture2D characters)
        {
            this.numbers = numbers;
            this.characters = characters;
        }

        public void DrawString(SpriteBatch device, Vector2 position, string text, float scale)
        {
            posX = position.X;
            text.ToList().ForEach(x => HandleLetter(x));
        }

        private void HandleLetter(char character)
        {
            int num;
            if (int.TryParse(character.ToString(), out num))    // number
            {
                Numbers code = DrawNumbers.ConvertIntToNumbers(num);
            }
            else if (true)  // character
            {
                Characters code = DrawCharacters.ConvertCharToCharacters(character);
            }
            else    // whitespace
            {

            }
        }
    }
}
