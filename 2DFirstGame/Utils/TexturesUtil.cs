using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.Utils
{
    public static class TexturesUtil
    {
        public static List<Rectangle> GetWallSource(Texture2D texture)
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<512; i += 64)
            {
                result.Add(new Rectangle(i, 0, 64, 64));
            }
            return result;
        }
    }

    public enum Walls
    {
        Left,
        Right,
        Up,
        Down,
        Left_Up,
        Left_Down,
        Right_Up,
        Right_Down
    }
}
