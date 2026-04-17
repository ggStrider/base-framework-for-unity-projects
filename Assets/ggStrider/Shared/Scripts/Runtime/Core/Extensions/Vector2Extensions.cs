using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class Vector2Extensions
    {
        public static Vector2 WithX(this Vector2 vec, float newX)
        {
            vec.x = newX;
            return vec;
        }

        public static Vector2 WithY(this Vector2 vec, float newY)
        {
            vec.y = newY;
            return vec;
        }

        public static Vector2 DirectionTo(this Vector2 from, Vector2 to)
        {
            return to - from;
        }

        public static Vector2 NormalizedDirectionTo(this Vector2 from, Vector2 to)
        {
            var origDir = from.DirectionTo(to);
            origDir.Normalize();

            return origDir;
        }
        
        public static bool IsCloseTo(this Vector2 from, Vector2 to, float maxDistance)
        {
            return (to - from).sqrMagnitude <= maxDistance * maxDistance;
        }
    }
}