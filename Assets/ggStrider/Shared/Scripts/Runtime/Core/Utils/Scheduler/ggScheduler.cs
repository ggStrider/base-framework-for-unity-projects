using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler
{
    public class ggScheduler : IScheduler
    {
        private readonly List<IScheduledHandle> _active = new();

        #region Public API

        public IScheduledHandle Delay(float seconds, Action callback, bool ignoreTimeScale = false,
            bool cancelImmediately = false, CancellationToken ct = default)
        {
            var handle = CreateHandle(ct);
            DelayAsync(seconds, callback, ignoreTimeScale, cancelImmediately, handle).Forget();

            return handle;
        }

        public IScheduledHandle DelayFrame(int frames, Action callback,
            bool cancelImmediately = false, CancellationToken ct = default)
        {
            var handle = CreateHandle(ct);
            DelayFrameAsync(frames, callback, cancelImmediately, handle).Forget();

            return handle;
        }

        public IScheduledHandle DelayOneFrame(Action callback,
            bool cancelImmediately = false, CancellationToken ct = default)
        {
            return DelayFrame(1, callback, cancelImmediately, ct);
        }

        public IScheduledHandle Repeat(float time, float repeatRate, Action callback,
            bool ignoreTimeScale, bool cancelImmediately = false, CancellationToken ct = default)
        {
            var handle = CreateHandle(ct);
            RepeatAsync(() => handle.IsActive, time, repeatRate, callback, handle, ignoreTimeScale, cancelImmediately)
                .Forget();

            return handle;
        }

        public IScheduledHandle RepeatUntil(Func<bool> condition, float time, float repeatRate, Action callback,
            bool ignoreTimeScale = false, bool cancelImmediately = false, CancellationToken ct = default)
        {
            var handle = CreateHandle(ct);
            RepeatAsync(condition, time, repeatRate, callback, handle, ignoreTimeScale, cancelImmediately).Forget();

            return handle;
        }

        public IScheduledHandle WaitUntil(Func<bool> predicate, Action callback,
            bool cancelImmediately = false, CancellationToken ct = default)
        {
            var handle = CreateHandle(ct);
            WaitUntilAsync(predicate, callback, cancelImmediately, handle).Forget();

            return handle;
        }

        public void CancelAll()
        {
            var copy = new List<IScheduledHandle>(_active);
            _active.Clear();

            for (var i = 0; i < copy.Count; i++)
            {
                copy[i].Cancel();
            }
        }

        #endregion

        private void RemoveFromList(ScheduledHandle scheduledHandle)
        {
            _active.Remove(scheduledHandle);
        }

        private ScheduledHandle CreateHandle(CancellationToken externalCt, bool addToActive = true)
        {
            var cts = CancellationTokenSource.CreateLinkedTokenSource(externalCt);
            var scheduled = new ScheduledHandle(cts, RemoveFromList);

            if (addToActive)
                _active.Add(scheduled);

            return scheduled;
        }

        private async UniTaskVoid DelayAsync(float seconds, Action callback, bool ignoreTimeScale,
            bool cancelImmediately, ScheduledHandle handle)
        {
            try
            {
                await UniTask.WaitForSeconds(seconds, cancelImmediately: cancelImmediately,
                    ignoreTimeScale: ignoreTimeScale, cancellationToken: handle.Token);

                callback?.Invoke();
                handle.Complete();
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                RemoveFromList(handle);
            }
        }

        private async UniTaskVoid RepeatAsync(Func<bool> condition, float timeToStart, float repeatRate,
            Action callback,
            ScheduledHandle handle,
            bool ignoreTimeScale, bool cancelImmediately)
        {
            try
            {
                if (timeToStart > 0)
                {
                    await UniTask.WaitForSeconds(timeToStart,
                        cancellationToken: handle.Token, ignoreTimeScale: ignoreTimeScale,
                        cancelImmediately: cancelImmediately);
                }

                while (condition())
                {
                    callback?.Invoke();

                    await UniTask.WaitForSeconds(repeatRate,
                        cancellationToken: handle.Token, ignoreTimeScale: ignoreTimeScale,
                        cancelImmediately: cancelImmediately);
                }

                handle.Complete();
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                RemoveFromList(handle);
            }
        }

        private async UniTaskVoid DelayFrameAsync(int frames, Action callback,
            bool cancelImmediately, ScheduledHandle handle)
        {
            try
            {
                await UniTask.DelayFrame(frames, cancelImmediately: cancelImmediately,
                    cancellationToken: handle.Token);

                callback?.Invoke();
                handle.Complete();
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                RemoveFromList(handle);
            }
        }

        private async UniTaskVoid WaitUntilAsync(Func<bool> condition, Action callback,
            bool cancelImmediately, ScheduledHandle handle)
        {
            try
            {
                await UniTask.WaitUntil(condition, cancelImmediately: cancelImmediately,
                    cancellationToken: handle.Token);

                callback?.Invoke();
                handle.Complete();
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                RemoveFromList(handle);
            }
        }
    }
}