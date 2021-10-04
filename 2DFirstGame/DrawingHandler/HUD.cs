using Microsoft.Xna.Framework.Graphics;

namespace _2DFirstGame.DrawingHandler
{
    public static class HUD
    {
        public static void DrawHUD(SpriteBatch device, Player player)
        {
            DrawHP(device, player.HP);
        }
        private static void DrawHP(SpriteBatch device, int hp)
        {
            bool half;
            int solid = hp / 2;
            if (hp % 2 != 0)
                half = true;
            else
                half = false;
            for(int i=0; i<5; i++)
            {
                if (i <= solid)
                {

                }
                else if (half)
                {

                }
                else
                {

                }
            }
        }
    }
}
