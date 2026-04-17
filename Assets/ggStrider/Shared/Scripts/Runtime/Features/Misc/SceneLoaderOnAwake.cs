using ggStrider.Shared.Scripts.Runtime.Core.Scenes;
using UnityEngine;
using Zenject;

namespace ggStrider.Shared.Scripts.Runtime.Features.Misc
{
    public class SceneLoaderOnAwake : MonoBehaviour
    {
        [SerializeField] private SceneCard _sceneToLoad;

        private ISceneLoader _sceneLoader;

        [Inject]
        private void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _sceneLoader.LoadScene(_sceneToLoad);
        }
    }
}