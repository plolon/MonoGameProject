using Microsoft.Xna.Framework.Media;

namespace _2DFirstGame.Sounds
{
    public static class SongPlayer
    {
        public static void PlayBackgroundSong(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
        /// <summary>
        /// Max volume = 1f
        /// </summary>
        /// <param name="volume"></param>
        public static void ChangeVolume(float volume)   // handle in settings
        {
            MediaPlayer.Volume = volume;
        }
    }
}
