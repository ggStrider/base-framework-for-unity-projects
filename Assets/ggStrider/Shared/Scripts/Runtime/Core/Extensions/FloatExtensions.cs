using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsBetween(this float original, float a, float b)
        {
            var min = Mathf.Min(a, b);
            var max = Mathf.Max(a, b);

            if (original < min)
                return false;

            if (original > max)
                return false;

            return true;
        }

        public static bool IsOpposite(this float a, float b)
        {
            if (a >= 0 && b >= 0)
                return false;

            if (a <= 0 && b <= 0)
                return false;

            return true;
        }
    }
}