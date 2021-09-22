using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.Utils
{
    public class TexturesUtil
    {
        private List<Rectangle> walls;
        private List<Rectangle> grounds;

        public SpriteBatch Device { get; set; }

        public Texture2D WallsT { get; set; }
        public Texture2D GroundsT { get; set; }

        public TexturesUtil(SpriteBatch device, Texture2D wallsT, Texture2D groundsT)
        {
            Device = device;

            WallsT = wallsT;
            GroundsT = groundsT;

            walls = GetWallSource();
            grounds = GetGroundSource();
        }

        public Rectangle GetSource(Walls wallType)
        {
            return walls[(int)wallType];
        }
        public Rectangle GetSource(Grounds groundType)
        {
            return grounds[(int)groundType];
        }


        private List<Rectangle> GetWallSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<194; i += 65)
            {
                result.Add(new Rectangle(i, 0, 64, 64));
            }
            return result;
        }
        private List<Rectangle> GetGroundSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<649; i += 65)
            {
                result.Add(new Rectangle(i, 0, 64, 64));
            }
            return result;
        }
    }

    public enum Walls
    {
        Wall_1,
        Wall_2,
        Wall_up,
    }
    public enum Grounds
    {
        Flat_1,
        Flat_2,
        Up_corner_righttup,
        Up_corner_rightdown,
        Up_corner_leftup,
        Up_corner_lefttdown,
        Up_down,
        Up_right,
        Up_left,
        Up_up,
    }
}
