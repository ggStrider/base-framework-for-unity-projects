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
    }
}