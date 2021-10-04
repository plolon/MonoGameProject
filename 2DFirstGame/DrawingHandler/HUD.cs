using _2DFirstGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DFirstGame.DrawingHandler
{
    public static class HUD
    {
        public static void DrawHUD(SpriteBatch device, TexturesUtil util, Player player)
        {
            DrawHP(device, util, player.HP);
        }
        private static void DrawHP(SpriteBatch device, TexturesUtil util, int hp)
        {
            int x = 30;
            bool half;
            int solid = hp / 2;
            if (hp % 2 != 0)
                half = true;
            else
                half = false;
            for(int i=0; i<5; i++)
            {
                if (i < solid)
                {
                    DrawHearth(device, util.HudT, new Rectangle(x, 20, 17, 17), util.GetSource(Hud.Hearth_Full));
                }
                else if (half)
                {
                    DrawHearth(device, util.HudT, new Rectangle(x, 20, 17, 17), util.GetSource(Hud.Hearth_Half));
                    half = false;
                }
                else
                {
                    DrawHearth(device, util.HudT, new Rectangle(x, 20, 17, 17), util.GetSource(Hud.Hearth_Empty));
                }
                x += 20;
            }
        }
        private static void DrawHearth(SpriteBatch device, Texture2D texture, Rectangle destination, Rectangle source)
        {
            device.Draw(texture, destination, source, Color.White);
        }
    }
}
