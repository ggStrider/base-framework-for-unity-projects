using Cysharp.Threading.Tasks;

namespace ggStrider.Shared.Scripts.Runtime.Core.Scenes
{
    public interface ISceneLoader
    {
        public UniTask LoadSceneAsync(SceneCard sceneToLoad);
        public void LoadScene(SceneCard sceneToLoad);
    }
}