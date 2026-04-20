using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 vec, float newX)
        {
            vec.x = newX;
            return vec;
        }

        public static Vector3 WithY(this Vector3 vec, float newY)
        {
            vec.y = newY;
            return vec;
        }

        public static Vector3 WithZ(this Vector3 vec, float newZ)
        {
            vec.z = newZ;
            return vec;
        }
        
        public static Vector3 AddX(this Vector3 vec, float add)
        {
            vec.x += add;
            return vec;
        }
        
        public static Vector3 AddY(this Vector3 vec, float add)
        {
            vec.y += add;
            return vec;
        }
        
        public static Vector3 AddZ(this Vector3 vec, float add)
        {
            vec.z += add;
            return vec;
        }

        public static Vector3 DirectionTo(this Vector3 from, Vector3 to)
        {
            return to - from;
        }

        public static Vector3 NormalizedDirectionTo(this Vector3 from, Vector3 to)
        {
            var origDir = from.DirectionTo(to);
            origDir.Normalize();

            return origDir;
        }

        public static bool IsCloseTo(this Vector3 from, Vector3 to, float maxDistance)
        {
            return (to - from).sqrMagnitude <= maxDistance * maxDistance;
        }
    }
}