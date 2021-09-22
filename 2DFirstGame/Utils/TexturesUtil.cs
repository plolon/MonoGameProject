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

        public SpriteBatch Device { get; set; }

        public Texture2D WallsT { get; set; }
        public Texture2D GroundsT { get; set; }
        public Texture2D Inside_wallsT { get; set; }

        public TexturesUtil(SpriteBatch device, Texture2D wallsT, Texture2D groundsT, Texture2D inside_wallsT)
        {
            Device = device;

            WallsT = wallsT;
            GroundsT = groundsT;
            Inside_wallsT = inside_wallsT;

            walls = GetWallSource();
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


        private List<Rectangle> GetWallSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for(int i=0; i<512; i += 65)
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
    public enum Grounds
    {
        Clear,
    }
}
