using Microsoft.Xna.Framework.Media;

namespace _2DFirstGame.Sounds
{
    public static class Background
    {
        public static void PlayBackgroundMusic(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
        public static void ChangeVolume(int num)
        {
            MediaPlayer.Volume = 5;
        }
    }
}
