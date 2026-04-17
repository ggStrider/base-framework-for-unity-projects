using System.Collections.Generic;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class ListExtensions
    {
        public static bool TryGetRandomElement<T>(this List<T> list, out T result)
        {
            result = default;

            if (list.IsNullOrEmpty())
                return false;

            var randomIndex = Random.Range(0, list.Count);
            result = list[randomIndex];

            return true;
        }
        
        public static T GetRandomElement<T>(this List<T> list)
        {
            if (list.TryGetRandomElement(out var t))
                return t;

            return default;
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }
    }
}
