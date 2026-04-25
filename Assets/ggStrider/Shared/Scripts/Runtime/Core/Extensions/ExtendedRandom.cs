using ggStrider.Shared.Scripts.Runtime.Core.Utils;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Extensions
{
    public static class ExtendedRandom
    {
        public static WeightedRandomElement<T> GetRandom<T>(WeightedRandomElement<T>[] arr)
        {
            if (arr.IsNullOrEmpty())
            {
                ggDebug.Error("Weighted random objs is null");
                return default;
            }

            float sum = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                sum += arr[i].Chance;
            }
            
            float random = Random.Range(0f, sum);
            for (int i = 0; i < arr.Length; ++i)
            {
                random -= arr[i].Chance;

                if (random <= 0)
                    return arr[i];
            }

            return arr[^1];
        }
    }

    public struct WeightedRandomElement<T>
    {
        public T Object;
        public float Chance;
    }
}