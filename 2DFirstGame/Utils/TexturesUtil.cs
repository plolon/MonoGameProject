using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.Utils
{
    public class TexturesUtil
    {
        private List<Rectangle> walls;
        private List<Rectangle> grounds;
        private List<Rectangle> inside_walls;

        public TexturesUtil()
        {
            walls = GetWallSource();
            inside_walls = GetInside_WallSource();
            grounds = new List<Rectangle>() { new Rectangle(0, 0, 64, 64) };
        }

        public Rectangle GetSource(Walls wallType)
        {
            return walls[(int)wallType];
        }
        public Rectangle GetSource(Grounds groundType)
        {
            return grounds[(int)groundType];
        }
        public Rectangle GetSource(Inside_Walls wallType)
        {
            return grounds[(int)wallType];
        }


        private List<Rectangle> GetWallSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<512; i += 64)
            {
                result.Add(new Rectangle(i, 0, 64, 64));
            }
            return result;
        }
        private List<Rectangle> GetInside_WallSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<323; i += 64)
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
    public enum Inside_Walls
    {
        Left,
        Right,
        Up,
        Down,
    }
    public enum Grounds
    {
        Clear,
    }
}
