using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public class EmptyLoadingScreen : MonoBehaviour, ILoadingScreen
    {
        public UniTask FadeToLoadingScreen()
        {
            return UniTask.CompletedTask;
        }

        public UniTask UnfadeFromLoadingScreen()
        {
            return UniTask.CompletedTask;
        }
    }
}