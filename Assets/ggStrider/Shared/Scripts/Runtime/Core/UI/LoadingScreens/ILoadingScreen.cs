using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public interface ILoadingScreen
    {
        public UniTask OnLoadingScene();
        public UniTask OnSceneLoaded();
    }
}