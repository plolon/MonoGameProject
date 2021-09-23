using _2DFirstGame.DrawingHandler.String.Utils;
using _2DFirstGame.Tiles;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace _2DFirstGame.Levels
{
    public static class TileHelper
    {
        private static Random random = new Random();
        public static Tile SwitchLetter(TexturesUtil texturesUtil, char letter, int x, int y)
        {
            Logger.Info($"{letter.ToString()}", ConsoleColor.Blue);
            Rectangle meta;
            switch (letter)
            {

                case '_':
                    meta = GetRandomMeta(new List<Rectangle>()
                            {   texturesUtil.GetSource(Grounds.Flat_1),
                                texturesUtil.GetSource(Grounds.Flat_2),
                                texturesUtil.GetSource(Grounds.Flat_3),
                                texturesUtil.GetSource(Grounds.Flat_4),});
                    return new Ground(new Rectangle(x, y, 64, 64), meta, true);
                case 'D':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Down), true);
                case 'R':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Right), true);
                case 'L':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Left), true);
                case 'U':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Up), true);
                case 'q':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RU), true);
                case 'j':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RD), true);
                case 'p':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LU), true);
                case 'k':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LD), true);
                case 'Q':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RU2), true);
                case 'J':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_RD2), true);
                case 'P':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LU2), true);
                case 'l':
                    return new Ground(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Grounds.Sand_Corner_LD2), true);
                case 'w':
                    meta = GetRandomMeta(new List<Rectangle>() { texturesUtil.GetSource(Walls.Wall_1), texturesUtil.GetSource(Walls.Wall_2) });
                    return new Wall(new Rectangle(x, y, 64, 64), meta);
                case 'W':
                    return new Wall(new Rectangle(x, y, 64, 64), texturesUtil.GetSource(Walls.Wall_up));
                default:
                    return null;
            }
        }
        private static Rectangle GetRandomMeta(List<Rectangle> from)
        {
            int rand = random.Next(0, from.Count);
            if (rand == 2)
            {
                rand = random.Next(0, from.Count);
            }
            return from[rand];
        }
    }
}
