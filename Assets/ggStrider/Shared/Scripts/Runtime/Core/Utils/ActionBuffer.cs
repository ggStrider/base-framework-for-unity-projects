using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils
{
    public struct ActionBuffer
    {
        private float _lastBuffer;
        private float _lastMaxDelay;

        private bool _wasBufferConsumed;

        public void BufferNow(float maxDelay)
        {
            _wasBufferConsumed = false;

            _lastBuffer = Time.time;
            _lastMaxDelay = maxDelay;
        }

        public bool IsBufferValid()
        {
            return Time.time <= _lastBuffer + _lastMaxDelay;
        }

        public bool TryConsumeBuffer()
        {
            if (_wasBufferConsumed)
                return false;

            var isValid = IsBufferValid();

            if (isValid)
                _wasBufferConsumed = true;

            return isValid;
        }

        public void Clear()
        {
            _wasBufferConsumed = false;

            _lastBuffer = 0f;
            _lastMaxDelay = 0f;
        }
    }
}