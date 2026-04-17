using ggStrider.Shared.Scripts.Runtime.Core.GameStates.States;

namespace ggStrider.Shared.Scripts.Runtime.Core.GameStates.Signals
{
    public struct SignalGameStateChanged
    {
        // can be null
        public IGameState Previous;
        public IGameState Current;

        public SignalGameStateChanged(IGameState prev, IGameState current)
        {
            Previous = prev;
            Current = current;
        }
    }
}