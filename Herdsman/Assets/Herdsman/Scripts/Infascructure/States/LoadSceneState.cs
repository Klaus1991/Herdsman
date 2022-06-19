using Herdsman.Factory;
using Infrastructure.Factory;
using Infrastructure.Models.Requests;
using Infrastructure.UnityContext;
using Infrastructure.UnityContext.SceneManagment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadSceneState : IStateWithArgument<LoadLevelRequest>
    {
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly IStateMachine StateMachine;
        private readonly IHudFactory UIFactory;

        private SceneLoader Loader { get; set; }

        public LoadSceneState(IStateMachine stateMachine, IFactoryContainer factoryContainer, ICoroutineRunner coroutine)
        {
            CoroutineRunner = coroutine;
            StateMachine = stateMachine;
            UIFactory = factoryContainer.Get<UIFactory>();

            Loader = new SceneLoader(CoroutineRunner);
        }

        public void Exit()
        {
            
        }

        public void Enter(LoadLevelRequest requests)
        {
            var sceneName = requests.SceneName;
            var onLoad = requests.OnLoadAction;
            Loader.Load(sceneName, onLoad);
        }
    }
}
