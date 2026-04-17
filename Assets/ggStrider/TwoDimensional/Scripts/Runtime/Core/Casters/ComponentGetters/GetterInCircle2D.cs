using System;
using ggStrider.Shared.Scripts.Runtime.Core.Casters.ComponentGetters;
using UnityEngine;

namespace ggStrider.TwoDimensional.Scripts.Runtime.Core.Casters.ComponentGetters
{
    [Serializable]
    public class GetterInCircle2D : IGetterInCast
    {
        [SerializeField] private float _radius;

        private const int MaxHits = 32;
        private readonly Collider2D[] _buffer = new Collider2D[MaxHits];

#if UNITY_6000_0_OR_NEWER
        private readonly ContactFilter2D _filter = new ContactFilter2D();

        public GetterInCircle2D(float radius)
        {
            _filter.useTriggers = false;
            _filter.SetLayerMask(Physics2D.AllLayers);
            _filter.useLayerMask = true;

            _radius = radius;
        }
#else
        public GetterInCircle2D(float radius)
        {
            _radius = radius;
        }
#endif

        public T GetFirst<T>(Vector3 origin, Vector3 direction)
        {
            int count = Overlap(origin);

            for (int i = 0; i < count; i++)
            {
                if (_buffer[i].TryGetComponent<T>(out var component))
                    return component;
            }

            return default;
        }

        public T[] GetInArea<T>(Vector3 origin, Vector3 direction)
        {
            int count = Overlap(origin);

            if (count == 0)
                return Array.Empty<T>();

            T[] result = new T[count];
            int index = 0;

            for (int i = 0; i < count; i++)
            {
                var component = _buffer[i].GetComponent<T>();
                if (component != null)
                {
                    result[index++] = component;
                }
            }

            if (index != count)
                Array.Resize(ref result, index);

            return result;
        }

        private int Overlap(Vector3 origin)
        {
#if UNITY_6000_0_OR_NEWER
            return Physics2D.OverlapCircle(
                origin,
                _radius,
                _filter,
                _buffer
            );
#else
            return Physics2D.OverlapCircleNonAlloc(
                origin,
                _radius,
                _buffer
            );
#endif
        }
    }
}