using System;
using System.Collections.Generic;
using ggStrider.Shared.Scripts.Runtime.Core.Reactive.Readonly;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Reactive
{
    [Serializable]
    public class ReactiveArray<T>
    {
        public ReactiveArray(int size, bool setSilent = false)
        {
            _array = new T[size];
        }

        public ReactiveArray(T[] startArray, bool setSilent = false)
        {
            _array = startArray;
        }

        [SerializeField] private T[] _array;

        public int Length => _array.Length;

        public T this[int index]
        {
            get => _array[index];
            set => SetValue(index, value);
        }

        /// <summary>
        /// index, oldValue, newValue
        /// </summary>
        public event Action<int, T, T> OnValueChanged;
        public event Action OnArrayChanged;
        public event Action<T[]> OnArrayInitialized;

        public void SetValue(int index, T newValue, bool force = false, bool setSilent = false)
        {
            if (!force)
            {
                if (EqualityComparer<T>.Default.Equals(_array[index], newValue))
                    return;
            }

            var oldValue = _array[index];
            _array[index] = newValue;

            if (!setSilent)
            {
                OnValueChanged?.Invoke(index, oldValue, newValue);
                OnArrayChanged?.Invoke();
            }
        }

        public void SetArray(T[] newArray, bool setSilent = false)
        {
            _array = newArray;

            if (!setSilent)
            {
                OnArrayInitialized?.Invoke(_array);
                OnArrayChanged?.Invoke();
            }
        }

        public T[] GetRawArray()
        {
            return _array;
        }

        public ReadOnlyReactiveArray<T> AsReadOnly()
        {
            return new ReadOnlyReactiveArray<T>(this);
        }
    }
}