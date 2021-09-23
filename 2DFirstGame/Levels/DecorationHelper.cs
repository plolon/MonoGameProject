using _2DFirstGame.DrawingHandler.String.Utils;
using _2DFirstGame.Tiles;
using _2DFirstGame.Tiles.Decorations;
using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;

namespace _2DFirstGame.Levels
{
    public static class DecorationHelper
    {
        public static Tile SwitchRow(TexturesUtil texturesUtil, string row)
        {
            if (row.StartsWith('c'))
            {
                return CreateCrate(texturesUtil, row);
            }
            else return null;
        }
        private static Tile CreateCrate(TexturesUtil texturesUtil, string row)
        {
            var param = row.Split('.');
            int x = int.Parse(param[1]);
            int y = int.Parse(param[2]);
            return new Crate(new Rectangle(x * 64, y * 64, 64, 64), texturesUtil.GetSource(Decorations.Crate));
        }
    }
}
