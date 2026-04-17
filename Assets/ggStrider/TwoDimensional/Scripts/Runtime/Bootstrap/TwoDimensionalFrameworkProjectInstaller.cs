using ggStrider.Shared.Scripts.Runtime.Core.Inputs;
using Zenject;

namespace ggStrider.TwoDimensional.Scripts.Runtime.Bootstrap
{
    public class TwoDimensionalFrameworkProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputReader>()
                .AsSingle()
                .NonLazy();
        }
    }
}