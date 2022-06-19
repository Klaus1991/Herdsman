using Herdsman.Factory;
using Herdsman.Logic;
using Herdsman.Utils;
using Infrastructure.Factory;
using Infrastructure.Models.Requests;
using Infrastructure.UnityContext;


namespace Infrastructure.States
{
    public class InitializeState : IStateNext
    {
        private readonly IPlayerFactory PlayerFactory;
        private readonly IStateMachine StateMachine;
        private readonly ICoroutineRunner CoroutineRunner;

        private IBuilder SetupBuilder { get; set; }

        public InitializeState(IStateMachine machine, IFactoryContainer factoryContainer, ICoroutineRunner coroutineRunner)
        {
            StateMachine = machine;
            CoroutineRunner = coroutineRunner;
            PlayerFactory = factoryContainer.Get<PlayerFactory>();
        }

        public void Enter()
        {
            SetupBuilder = new GameSetup(PlayerFactory);
            SetupBuilder.Build();
            var loadLevelRequest = new LoadLevelRequest
            {
                SceneName = SceneUtils.GAME_SCENE_NAME,
                OnLoadAction = OnSceneLoaded
            };
            StateMachine.EnterState<LoadSceneState, LoadLevelRequest>(loadLevelRequest);
        }

        public void Exit()
        {
            SetupBuilder?.Dispose();
            SetupBuilder = null;
        }

        // events
        private void OnSceneLoaded()
        {
            StateMachine.EnterState<MenuState>();
        }
    }
}
