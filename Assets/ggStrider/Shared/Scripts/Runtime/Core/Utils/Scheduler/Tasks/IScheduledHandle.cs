namespace ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler.Tasks
{
    public interface IScheduledHandle
    {
        bool IsActive { get; }
        void Cancel();
    }
}