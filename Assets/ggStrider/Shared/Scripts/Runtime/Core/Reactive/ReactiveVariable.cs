using System;
using System.Collections.Generic;
using ggStrider.Shared.Scripts.Runtime.Core.Reactive.Readonly;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Reactive
{
    [Serializable]
    public class ReactiveVariable<T>
    {
        public ReactiveVariable(T startValue, bool setSilent = false)
        {
            SetValue(startValue, setSilent);
        }

        public ReactiveVariable()
        {
        }

        [SerializeField] private T _value;

        public T Value
        {
            get => _value;
            set => SetValue(value);
        }

        /// <summary>
        /// Invokes when _value changes
        /// T1 - Old Value
        /// T2 - New Value
        /// </summary>
        public event Action<T, T> OnValueChanged;

        public event Action OnValueChangedNoArguments;

        public void SetValue(T newValue, bool force = false, bool setSilent = false)
        {
            if (!force)
            {
                if (EqualityComparer<T>.Default.Equals(newValue, _value)) return;
            }

            var oldValue = _value;
            _value = newValue;

            if (!setSilent)
            {
                OnValueChanged?.Invoke(oldValue, newValue);
                OnValueChangedNoArguments?.Invoke();
            }
        }

        public ReadOnlyReactiveVariable<T> AsReadOnly()
        {
            return new ReadOnlyReactiveVariable<T>(this);
        }
    }
}