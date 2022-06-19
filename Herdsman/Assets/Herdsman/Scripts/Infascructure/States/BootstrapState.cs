using Infrastructure.Factory;
using Infrastructure.UnityContext;
using Herdsman.Factory;
using Herdsman.Services;

namespace Infrastructure.States
{
    public class BootstrapState : IStateNext
    {
        private readonly IFactoryContainer FactoryContainer;
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly IUpdateLoop UnityUpdater;

        private IStateMachine StateMachine { get; set; }

        public BootstrapState(IStateMachine stateMachine, IFactoryContainer factoryContainer, ICoroutineRunner coroutineRunner, IUpdateLoop updateLoop)
        {
            StateMachine = stateMachine;
            FactoryContainer = factoryContainer;
            CoroutineRunner = coroutineRunner;
            UnityUpdater = updateLoop;

            RegisterServices();
            RegisterFactories();
        }

        public void Enter()
        {
            StateMachine.EnterState<InitializeState>();
        }

        private void RegisterServices()
        {
            var inputService = new PCPlayerInput(UnityUpdater);

            Services.Services.RegisterService(inputService);
        }

        private void RegisterFactories()
        {
            var playerFactory = new PlayerFactory();
            var uiFactory = new UIFactory();
            var animalFactory = new AnimalFactory();

            FactoryContainer.Register<PlayerFactory>(playerFactory);
            FactoryContainer.Register<UIFactory>(uiFactory);
            FactoryContainer.Register<AnimalFactory>(animalFactory);
        }

        public void Exit() { }
    }
}
