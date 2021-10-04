using _2DFirstGame.Utils;
using System;

namespace _2DFirstGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Config.Width = 800;
            Config.Height = 480;


            //using (var game = new MainMenu())
            //    game.Run();

            //using (var game = new Game2())
            //    game.Run();
            using (var game = new Game3())
                game.Run();
            
        }
    }
}
