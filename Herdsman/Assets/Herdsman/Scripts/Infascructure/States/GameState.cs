using Herdsman.Factory;
using Herdsman.Logic;
using Herdsman.Services;
using Infrastructure.Factory;
using Infrastructure.UnityContext;

namespace Infrastructure.States
{
    public class GameState : IStateNext
    {
        private readonly IHudFactory UIFactory;
        private readonly IPlayerFactory PlayerFactory;
        private readonly IStateMachine StateMachine;
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly IPlayerInput PlayerInput;
        private readonly IAnimalFactory AnimalFactory;

        private IGameBuilder GameBuilder { get; set; }

        public GameState(IStateMachine machine, IFactoryContainer factoryContainer, ICoroutineRunner coroutineRunner)
        {
            CoroutineRunner = coroutineRunner;
            StateMachine = machine;
            UIFactory = factoryContainer.Get<UIFactory>();
            AnimalFactory = factoryContainer.Get<AnimalFactory>();
            PlayerFactory = factoryContainer.Get<PlayerFactory>();
            PlayerInput = Services.Services.Get<PCPlayerInput>();
        }

        public void Enter()
        {
            GameBuilder = new Game(CoroutineRunner, UIFactory, PlayerFactory, AnimalFactory, PlayerInput);
            GameBuilder.Build();
            GameBuilder.OnNextState += OnNextState;
        }

        public void Exit()
        {
            GameBuilder.OnNextState -= OnNextState;
            GameBuilder.Dispose();
            GameBuilder = null;
        }

        // events
        private void OnNextState()
        {
            // TODO : Add game end state
        }
    }
}
