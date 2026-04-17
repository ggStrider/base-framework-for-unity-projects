using System;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Serializators
{
    [Serializable]
    public class PrefabInterfaceReference<T> where T : class
    {
        [SerializeField] private MonoBehaviour _prefab;

        public T Value => _prefab as T;
        public MonoBehaviour Object => _prefab;

        public bool HasValue => Value != null;
    }
}