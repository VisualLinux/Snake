namespace Snake
{
    public static class MathHelper
    {
        public static int BoundedAdd(int a, int b, int max, int min)
        {
            if (a + b > max)
            {
                return a + b - max - 1 + min;
            }
            if (a + b < min)
            {
                return a + b + max + 1;
            }
            return a + b;
        }
    }
}
