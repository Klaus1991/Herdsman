
namespace Infrastructure.States
{
    public interface IStateMachine
    {
        void EnterState<TState>() where TState : IExitableState;

        void EnterState<TState, TArgs>(TArgs args) where TState : IExitableState;
    }
}
