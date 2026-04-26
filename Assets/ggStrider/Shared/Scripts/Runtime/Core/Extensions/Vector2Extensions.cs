using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public enum Axis2D
    {
        X = 0,
        Y = 1,
    };
    
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
        
        public static Vector2 AddX(this Vector2 vec, float add)
        {
            vec.x += add;
            return vec;
        }
        
        public static Vector2 AddY(this Vector2 vec, float add)
        {
            vec.y += add;
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

        public static Vector2 Swap(this Vector2 vec, Axis2D a, Axis2D b)
        {
            (vec[(int)a], vec[(int)b]) = (vec[(int)b], vec[(int)a]);
            return vec;
        }
        
        public static bool Approximately(this Vector2 source, Vector2 approx)
        {
            return Mathf.Approximately(source.x, approx.x) &&
                   Mathf.Approximately(source.y, approx.y);
        }
    }
}