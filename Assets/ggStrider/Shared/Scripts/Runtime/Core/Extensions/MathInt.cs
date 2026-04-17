namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class MathInt
    {
        public static int Clamp(int current, int min, int max)
        {
            if (current > max)
                return max;

            if (current < min)
                return min;

            return current;
        }

        public static int Clamp01(int current)
        {
            return Clamp(current, 0, 1);
        }

        public static int Min(int a, int b)
        {
            if (a < b)
                return a;

            return b;
        }

        public static int Min(params int[] values)
        {
            if (values.Length == 0)
                return 0;

            int min = values[0];
            for (int i = 1; i < values.Length; ++i)
            {
                if (values[i] < min)
                    min = values[i];
            }

            return min;
        }
        
        public static int Max(params int[] values)
        {
            if (values.Length == 0)
                return 0;

            int max = values[0];
            for (int i = 1; i < values.Length; ++i)
            {
                if (values[i] > max)
                    max = values[i];
            }

            return max;
        }

        public static int Max(int a, int b)
        {
            if (a > b)
                return a;

            return b;
        }

        public static int Abs(int a)
        {
            return a == int.MinValue ? int.MaxValue : (a < 0 ? -a : a);
        }

        public static int Sign(int current)
        {
            if (current > 0)
                return 1;

            if (current < 0)
                return -1;

            return 0;
        }

        public static int Repeat(int current, int length)
        {
            if (current >= length)
                return 0;

            if (current < 0)
                return 0;

            return current;
        }
    }
}