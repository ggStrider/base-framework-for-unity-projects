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
    }
}