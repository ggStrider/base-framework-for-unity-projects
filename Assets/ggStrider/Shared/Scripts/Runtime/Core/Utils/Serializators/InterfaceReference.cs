using System;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Serializators
{
    [Serializable]
    public class InterfaceReference<T> where T : class
    {
        [SerializeField] private MonoBehaviour _object;
    
        public T Value => _object as T;
        public MonoBehaviour Object => _object;
        public bool HasValue => Value != null;
    }
}