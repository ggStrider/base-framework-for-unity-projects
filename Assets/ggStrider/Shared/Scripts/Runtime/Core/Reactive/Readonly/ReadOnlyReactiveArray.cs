using System;

namespace ggStrider.Shared.Scripts.Runtime.Core.Reactive.Readonly
{
    public class ReadOnlyReactiveArray<T>
    {
        private readonly ReactiveArray<T> _source;

        public ReadOnlyReactiveArray(ReactiveArray<T> source)
        {
            _source = source;
        }

        public int Length => _source.Length;

        public T this[int index] => _source[index];

        public event Action<int, T, T> OnValueChanged
        {
            add => _source.OnValueChanged += value;
            remove => _source.OnValueChanged -= value;
        }

        public event Action OnArrayChanged
        {
            add => _source.OnArrayChanged += value;
            remove => _source.OnArrayChanged -= value;
        }

        public event Action<T[]> OnArrayInitialized
        {
            add => _source.OnArrayInitialized += value;
            remove => _source.OnArrayInitialized -= value;
        }

        public T[] ToArray() => 
            _source.GetRawArray();
    }
}