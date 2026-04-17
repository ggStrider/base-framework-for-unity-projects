using System;
using System.Threading;
using ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler
{
    public interface IScheduler
    {
        public IScheduledHandle Delay(float seconds, Action callback, bool ignoreTimeScale = false,
            bool cancelImmediately = false, CancellationToken ct = default);

        public IScheduledHandle DelayFrame(int frames, Action callback,
            bool cancelImmediately = false, CancellationToken ct = default);

        public IScheduledHandle DelayOneFrame(Action callback,
            bool cancelImmediately = false, CancellationToken ct = default);

        public IScheduledHandle Repeat(float time, float repeatRate, Action callback,
            bool ignoreTimeScale, bool cancelImmediately = false, CancellationToken ct = default);
        
        public IScheduledHandle RepeatUntil(Func<bool> condition, float time, float repeatRate, Action callback,
            bool ignoreTimeScale = false, bool cancelImmediately = false, CancellationToken ct = default);

        public IScheduledHandle WaitUntil(Func<bool> predicate, Action callback,
            bool cancelImmediately = false, CancellationToken ct = default);

        public void CancelAll();
    }
}