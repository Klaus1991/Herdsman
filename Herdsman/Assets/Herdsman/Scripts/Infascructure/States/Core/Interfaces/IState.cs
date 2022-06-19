namespace Infrastructure.States
{
    public interface IStateNext : IExitableState
    {
        void Enter();
    }
}
