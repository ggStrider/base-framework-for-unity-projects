namespace ggStrider.Shared.Scripts.Runtime.Core.GameStates.States
{
    public interface IGameState
    {
        public void OnEnter();
        public void OnExit(IGameState nextState);
    }
}