using ggStrider.Shared.Scripts.Runtime.Core.GameStates.Signals;
using ggStrider.Shared.Scripts.Runtime.Core.GameStates.States;
using Zenject;

namespace ggStrider.Shared.Scripts.Runtime.Core.GameStates
{
    public class GameStateManager
    {
        [Inject]
        public GameStateManager(DiContainer container, SignalBus signalBus)
        {
            _container = container;
            _signalBus = signalBus;

            SetNewState<ExampleStartGameState>();
        }

        public IGameState CurrentState { get; private set; }

        // DI
        private readonly DiContainer _container;
        private readonly SignalBus _signalBus;

        public bool SetNewState<T>() where T : IGameState, new()
        {
            if (CurrentState is T)
                return false;

            var newState = _container.Instantiate<T>();
            var prev = CurrentState;

            CurrentState?.OnExit(newState);
            CurrentState = newState;
            CurrentState?.OnEnter();

            _signalBus.Fire<SignalGameStateChanged>(new SignalGameStateChanged(prev, CurrentState));

            return true;
        }
    }
}