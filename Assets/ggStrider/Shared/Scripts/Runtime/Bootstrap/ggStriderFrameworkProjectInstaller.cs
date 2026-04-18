using ggStrider.Shared.Scripts.Runtime.Core.Audio.Services;
using ggStrider.Shared.Scripts.Runtime.Core.Data;
using ggStrider.Shared.Scripts.Runtime.Core.Data.Services;
using ggStrider.Shared.Scripts.Runtime.Core.GameStates.Signals;
using ggStrider.Shared.Scripts.Runtime.Core.Scenes;
using ggStrider.Shared.Scripts.Runtime.Core.UI.LoadingScreens;
using ggStrider.Shared.Scripts.Runtime.Core.UI.Panels.Managers;
using ggStrider.Shared.Scripts.Runtime.Core.Utils.Scheduler;
using ggStrider.Shared.Scripts.Runtime.Core.Utils.Serializators;
using ggStrider.Shared.Scripts.Runtime.Features.Data.Services;
using UnityEngine;
using Zenject;

namespace ggStrider.Shared.Scripts.Runtime.Bootstrap
{
    // ReSharper disable once InconsistentNaming
    public class ggStriderFrameworkProjectInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvasWhereInstantiateUI;
        [SerializeField] private PrefabInterfaceReference<ILoadingScreen> _loadingScreenPrefab;

        [Space] [SerializeField] private AudioServiceDependencies _audioServiceDependencies;

        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            InstallSignals();

            Container.Bind<ILoadingScreen>()
                .FromComponentInNewPrefab(_loadingScreenPrefab.Object)
                .UnderTransform(_canvasWhereInstantiateUI.transform)
                .AsSingle()
                .NonLazy();

            Container.Bind<IUIPanelManager>()
                .To<UIPanelManager>()
                .AsSingle()
                .NonLazy();

            Container.Bind<ISceneLoader>()
                .To<SceneLoader>()
                .AsSingle()
                .NonLazy();

            Container.Bind<PlayerData>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IPlayerDataService>()
                .To<PlayerDataService>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IScheduler>()
                .To<ggScheduler>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IAudioService>()
                .To<AudioService>()
                .AsSingle()
                .WithArguments(_audioServiceDependencies)
                .NonLazy();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<SignalGameStateChanged>()
                .OptionalSubscriber();
        }
    }
}