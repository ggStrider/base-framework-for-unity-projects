using System;
using System.Threading;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler.Tasks
{
    public class ScheduledHandle : IScheduledHandle
    {
        public bool IsActive { get; private set; } = true;

        private CancellationTokenSource _cts;
        public CancellationToken Token => _cts.Token;

        private event Action<ScheduledHandle> OnCancel;

        public ScheduledHandle(CancellationTokenSource cts, Action<ScheduledHandle> onCancel)
        {
            _cts = cts;
            OnCancel = onCancel;
        }

        public void Cancel()
        {
            if (!IsActive)
                return;
            
            IsActive = false;
            _cts.Cancel();
            _cts.Dispose();

            _cts = null;
            
            OnCancel?.Invoke(this);
        }

        public void Complete()
        {
            if(!IsActive)
                return;
            
            IsActive = false;
            _cts.Dispose();
        }
    }
}