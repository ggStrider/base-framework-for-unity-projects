using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class BoolExtensions
    {
        public static bool RandomBool()
        {
            return Random.value > 0.5f;
        }

        public static int ToInt(this bool source)
        {
            return source ? 1 : 0;
        }
        
        public static float ToFloat(this bool source)
        {
            return source ? 1f : 0f;
        }

        public static bool IntToBool(this int i)
        {
            if (i > 0)
                return true;

            return false;
        }

        public static bool FloatToBool(this float f)
        {
            if (f > 0)
                return true;

            return false;
        }
    }
}