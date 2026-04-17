using System;

namespace ggStrider.Shared.Scripts.Runtime.Core.Reactive.Readonly
{
    public class ReadOnlyReactiveVariable<T>
    {
        private readonly ReactiveVariable<T> _source;

        public ReadOnlyReactiveVariable(ReactiveVariable<T> source)
        {
            _source = source;
        }

        public T Value => _source.Value;

        public event Action<T, T> OnValueChanged
        {
            add => _source.OnValueChanged += value;
            remove => _source.OnValueChanged -= value;
        }

        public event Action OnValueChangedNoArguments
        {
            add => _source.OnValueChangedNoArguments += value;
            remove => _source.OnValueChangedNoArguments -= value;
        }
    }
}