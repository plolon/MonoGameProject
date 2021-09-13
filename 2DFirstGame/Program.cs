using System;

namespace _2DFirstGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainMenu())
                game.Run();

            using (var game = new Game2())
                game.Run();
            
        }
    }
}
