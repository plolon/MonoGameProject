using Microsoft.Xna.Framework;

namespace _2DFirstGame.DrawingHandler
{
    public class AnimationString
    {
        public void Draw(Vector2 position, string text)
        {

        }
    }

    public class LetterToAnimate
    {
        public char Character { get; set; }
        public Vector2 Position { get; set; }
        public LetterToAnimate(Vector2 position, char character)
        {
            Position = position;
            Character = character;
        }
    }
}
