namespace _2DFirstGame.DrawingHandler.String
{
    public static class DrawNumbers
    {
        public static Numbers ConvertIntToNumbers(int number)
        {
            if (number == 0)
            {
                return Numbers.Zero;
            }
            else
            {
                return (Numbers)number - 1;
            }
        }
    }
}
