using Microsoft.Xna.Framework;

namespace _2DFirstGame
{
    public class Player
    {
        public int HP { get; set; }
        public Vector2 Position { get; set; }

        public Player(int hp)
        {
            HP = hp;
        }
    }
}
