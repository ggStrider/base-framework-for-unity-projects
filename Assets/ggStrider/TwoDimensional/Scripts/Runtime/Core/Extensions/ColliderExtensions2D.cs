using ggStrider.Shared.Scripts.Runtime.Core.Extensions;
using UnityEngine;

namespace ggStrider.TwoDimensional.Scripts.Runtime.Core.Extensions
{
    public static class ColliderExtensions2D
    {
        public static Vector3 UpperRight(this Collider2D col)
        {
            return col.bounds.max;
        }

        public static Vector3 UpperLeft(this Collider2D col)
        {
            var upperLeft = col.UpperRight()
                .WithX(col.bounds.min.x);

            return upperLeft;
        }

        public static Vector3 BottomLeft(this Collider2D col)
        {
            return col.bounds.min;
        }

        public static Vector3 BottomRight(this Collider2D col)
        {
            var bottomRight = col.BottomLeft()
                .WithX(col.bounds.max.x);

            return bottomRight;
        }
    }
}