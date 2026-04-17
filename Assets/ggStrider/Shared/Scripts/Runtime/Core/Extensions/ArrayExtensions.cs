using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class ArrayExtensions
    {
        public static bool TryGetRandomElement<T>(this T[] arr, out T result)
        {
            result = default;

            if (arr.IsNullOrEmpty())
                return false;

            var randomIndex = Random.Range(0, arr.Length);
            result = arr[randomIndex];

            return true;
        }
        
        public static T GetRandomElement<T>(this T[] arr)
        {
            if (arr.TryGetRandomElement(out var t))
                return t;

            return default;
        }

        public static bool IsNullOrEmpty<T>(this T[] arr)
        {
            return arr == null || arr.Length == 0;
        }
    }
}