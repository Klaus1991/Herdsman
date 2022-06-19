using Herdsman.Factory;
using Herdsman.Logic;
using Herdsman.Logic.UI;
using Herdsman.Utils;
using Infrastructure.Factory;
using Infrastructure.Models.Requests;
using Infrastructure.UnityContext;


namespace Infrastructure.States
{
    public class MenuState : IStateNext
    {
        private readonly IHudFactory UIFactory;
        private readonly IStateMachine StateMachine;

        private IGameMenu MenuBuilder { get; set; }

        public MenuState(IStateMachine machine, IFactoryContainer factoryContainer)
        {
            StateMachine = machine;
            UIFactory = factoryContainer.Get<UIFactory>();
        }

        public void Enter()
        {
            MenuBuilder = new GameMenu(UIFactory);
            MenuBuilder.Build();
            MenuBuilder.OnNextState += OnNextState;
        }

        public void Exit()
        {
            MenuBuilder.OnNextState -= OnNextState;
            MenuBuilder.Dispose();
            MenuBuilder = null;
        }

        // events
        private void OnNextState()
        {
            StateMachine.EnterState<GameState>();
        }
    }
}
