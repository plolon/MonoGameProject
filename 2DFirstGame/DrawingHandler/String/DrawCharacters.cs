using System;

namespace _2DFirstGame.DrawingHandler.String
{
    public static class DrawCharacters
    {
        public static Characters ConvertCharToCharacters(char character)
        {
            char ch = Char.ToLower(character);
            int code = (int)ch - 97;
            if (code < 0 || code > 122)
            {
                throw new Exception("TODO: handle special characters");
            }
            else
            {
                if (code == 0)
                {
                    return Characters.Z;
                }
                return (Characters)code;
            }
        }
    }
}
