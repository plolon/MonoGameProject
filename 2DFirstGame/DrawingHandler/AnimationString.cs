using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace _2DFirstGame.DrawingHandler
{
    public class AnimationString
    {
        private List<LetterToAnimate> animationLetters;
        private float starting;
        private int currentlyUp;
        private SpriteBatch spriteBatch;
        private DrawingHelper drawingHelper;


        public AnimationString(SpriteBatch spriteBatch, DrawingHelper drawingHelper, Vector2 position, string text)
        {
            this.spriteBatch = spriteBatch;
            this.drawingHelper = drawingHelper;
            animationLetters = CreateAnimationString(position, text);
            starting = position.X;
            currentlyUp = animationLetters.Count() - 1;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animate();
            foreach(var item in animationLetters)
            {
                drawingHelper.DrawString(item.Position, item.Character.ToString(), 1f);
            }
        }

        private void Animate()
        {
            for (int i = animationLetters.Count - 1; i >= 0; i--)
            {
                if(i == currentlyUp)
                {
                    animationLetters[i].Position = new Vector2(starting, animationLetters[i].Position.Y - 10);
                }
                else
                {
                    animationLetters[i].Position = new Vector2(starting, starting);
                }
            }
            currentlyUp--;
            if (currentlyUp < 0)
            {
                currentlyUp = animationLetters.Count() - 1;
            }
        }

        private List<LetterToAnimate> CreateAnimationString(Vector2 position, string text)
        {
            List<LetterToAnimate> animation = new List<LetterToAnimate>();
            text.ToList().ForEach(x => animation.Add(new LetterToAnimate(position, x)));
            return animation;
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
