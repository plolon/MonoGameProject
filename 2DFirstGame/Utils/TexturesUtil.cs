using _2DFirstGame.DrawingHandler.String.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace _2DFirstGame.Utils
{
    public class TexturesUtil
    {
        private List<Rectangle> walls;
        private List<Rectangle> grounds;
        private List<Rectangle> decorations;
        private List<Rectangle> hud;

        public SpriteBatch Device { get; set; }

        public Texture2D WallsT { get; set; }
        public Texture2D GroundsT { get; set; }
        public Texture2D DecorationsT { get; set; }
        public Texture2D HudT { get; set; }

        public TexturesUtil(SpriteBatch device, Texture2D wallsT, Texture2D groundsT, Texture2D decorationsT, Texture2D hudT)
        {
            Device = device;

            WallsT = wallsT;
            GroundsT = groundsT;
            DecorationsT = decorationsT;
            HudT = hudT;

            walls = GetWallSource();
            grounds = GetGroundSource();
            decorations = GetDecorationSource();
            hud = GetHudSource();
        }

        public Rectangle GetSource(Walls wallType)
        {
            return walls[(int)wallType];
        }
        public Rectangle GetSource(Grounds groundType)
        {
            return grounds[(int)groundType];
        }
        public Rectangle GetSource(Decorations decorationType)
        {
            return decorations[(int)decorationType];
        }


        private List<Rectangle> GetGroundSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int y = 0; y < 258; y += 65)
            {
                for (int x = 0; x < 259; x += 65)
                {
                    Logger.Info($"{x},{y}", null);
                    result.Add(new Rectangle(x, y, 64, 64));
                }
            }
            return result;
        }
        private List<Rectangle> GetWallSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int i = 0; i < 194; i += 65)
            {
                result.Add(new Rectangle(i, 0, 64, 64));
            }
            return result;
        }
        private List<Rectangle> GetDecorationSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int i = 0; i < 70; i += 71)
            {
                result.Add(new Rectangle(i, 0, 70, 70));
            }
            return result;
        }
        private List<Rectangle> GetHudSource()
        {
            List<Rectangle> result = new List<Rectangle>();
            for (int i = 0; i < 53; i += 18)
            {
                result.Add(new Rectangle(i, 0, 17, 17));
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
    public enum Decorations
    {
        Crate,
    }
    public enum Hud
    {
        Hearth_Full,
        Hearth_Half,
        Hearth_Empty,
    }
}
