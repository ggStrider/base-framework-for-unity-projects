using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.Utils
{
    /// <summary>
    /// Do callback after certain delay.
    ///
    /// Better to not use this class,
    /// because there are better and controllable alternative: ggScheduler.
    /// The only con of ggScheduler is it only injects by Zenject
    /// </summary>
    public static class CooldownRunner
    {
        #region Seconds

        public static void WaitForSeconds(float seconds, Action callback, CancellationToken cancellationToken = default)
        {
            WaitForSecondsAsync(seconds, callback, cancellationToken).Forget();
        }

        private static async UniTaskVoid WaitForSecondsAsync(float seconds, Action callback,
            CancellationToken cancellationToken = default)
        {
            try
            {
                await UniTask.WaitForSeconds(seconds, cancellationToken: cancellationToken);
                callback?.Invoke();
            }
            catch (OperationCanceledException)
            {
            }
        }

        #endregion

        #region Frames

        public static void WaitOneFrame(Action callback, CancellationToken cancellationToken = default)
        {
            const int oneFrame = 1;
            WaitForFramesAsync(oneFrame, callback, cancellationToken).Forget();
        }
        
        public static void WaitForFrames(int frames, Action callback,
            CancellationToken cancellationToken = default)
        {
            WaitForFramesAsync(frames, callback, cancellationToken).Forget();
        }

        private static async UniTaskVoid WaitForFramesAsync(int frames, Action callback, CancellationToken cancellationToken = default)
        {
            try
            {
                await UniTask.DelayFrame(frames, cancellationToken: cancellationToken);
                callback?.Invoke();
            }
            catch (OperationCanceledException)
            {
            }
        }

        #endregion
    }
}