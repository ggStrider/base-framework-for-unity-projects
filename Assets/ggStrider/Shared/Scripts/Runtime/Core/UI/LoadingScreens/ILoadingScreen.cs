using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens
{
    public interface ILoadingScreen
    {
        public UniTask FadeToLoadingScreen();
        public UniTask UnfadeFromLoadingScreen();
    }
}