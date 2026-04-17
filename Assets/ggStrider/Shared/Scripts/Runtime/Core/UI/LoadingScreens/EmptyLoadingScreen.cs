using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public class EmptyLoadingScreen : MonoBehaviour, ILoadingScreen
    {
        public UniTask OnLoadingScene()
        {
            return UniTask.CompletedTask;
        }

        public UniTask OnSceneLoaded()
        {
            return UniTask.CompletedTask;
        }
    }
}