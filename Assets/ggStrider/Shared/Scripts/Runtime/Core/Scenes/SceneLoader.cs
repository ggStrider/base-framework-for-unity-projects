using System;
using Cysharp.Threading.Tasks;
using ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens;
using UnityEngine.SceneManagement;

namespace ggStrider.Shared.Scripts.Runtime.Core.Scenes
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ILoadingScreen _loadingScreen;
        
        public SceneLoader(ILoadingScreen loadingScreen)
        {
            _loadingScreen = loadingScreen;
        }
        
        public async UniTask LoadSceneAsync(SceneCard sceneToLoad)
        {
            try
            {
                await _loadingScreen.OnLoadingScene();
                UniTask loading = SceneManager.LoadSceneAsync(sceneToLoad.SceneFileName).ToUniTask();
                await loading;
                
                _loadingScreen.OnSceneLoaded().Forget();
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void LoadScene(SceneCard sceneToLoad)
        {
            LoadSceneAsync(sceneToLoad).Forget();
        }
    }
}