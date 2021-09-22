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
            for(int y=0; y<258; y += 65)
            {
                for(int x=0; x<259; x += 65)
                {
                    result.Add(new Rectangle(x,y,64,64));
                }
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
        Sand_Down,
        Sand_Right,
        Sand_Left,
        Sand_Up,
        Sand_Corner_RU,
        Sand_Corner_RD,
        Sand_Corner_LU,
        Sand_Corner_LD,
        Sand_Corner_RU2,
        Sand_Corner_RD2,
        Sand_Corner_LU2,
        Sand_Corner_LD2,
        Flat_1,
        Flat_2,
        Flat_3,
        Flat_4,
    }
}
