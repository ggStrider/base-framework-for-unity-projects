using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.Panels
{
    public abstract class BasePanelUI : MonoBehaviour, IPanelUI
    {
        public bool IsVisible { get; private set; }

        public async UniTask Show()
        {
            gameObject.SetActive(true);
            IsVisible = true;

            await OnShow();
        }

        public async UniTask Hide()
        {
            await OnHide();

            IsVisible = false;
            gameObject.SetActive(false);
        }

        protected virtual UniTask OnShow() => UniTask.CompletedTask;
        protected virtual UniTask OnHide() => UniTask.CompletedTask;
    }
}