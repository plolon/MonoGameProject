using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2DFirstGame.Levels
{
    public static class LevelUtil
    {

        public static List<string> GetLevelBasics(string path)
        {
            string input;
            using (StreamReader file = new StreamReader(path))
            {
                input = file.ReadToEnd();
                file.Close();
            }
            return input.Split('|').ToList();
        }
        public static List<string> GetLevelInfo(string tiles)
        {
            return tiles.Split(',').ToList();
        }
    }
}
