using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public enum Axis3D
    {
        X = 0,
        Y = 1,
        Z = 2
    };
    
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

        public static bool Approximately(this Vector3 source, Vector3 approx)
        {
            return Mathf.Approximately(source.x, approx.x) &&
                   Mathf.Approximately(source.y, approx.y) &&
                   Mathf.Approximately(source.z, approx.z);
        }
        
        public static Vector2 Swap(this Vector2 vec, Axis3D a, Axis3D b)
        {
            (vec[(int)a], vec[(int)b]) = (vec[(int)b], vec[(int)a]);
            return vec;
        }
    }
}