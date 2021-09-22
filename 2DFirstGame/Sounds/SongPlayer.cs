using Microsoft.Xna.Framework.Media;

namespace _2DFirstGame.Sounds
{
    public static class SongPlayer
    {
        public static void PlayBackgroundSong(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
<<<<<<< HEAD
            MediaPlayer.Volume = 0.1f;
=======
            MediaPlayer.Volume = 0.01f;
>>>>>>> new_textures
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
