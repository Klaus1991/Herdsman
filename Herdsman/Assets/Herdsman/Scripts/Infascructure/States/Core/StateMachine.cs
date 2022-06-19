using Infrastructure.Factory;
using Infrastructure.UnityContext;
using System;
using System.Collections;
using System.Collections.Generic;
using Herdsman.Factory;

namespace Infrastructure.States
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> States;

        private IExitableState Current { get; set; }

        public StateMachine(ICoroutineRunner coroutine, IUpdateLoop updateLoop, FactoryContainer factoryContainer)
        {
            States = new Dictionary<Type, IExitableState>();
            // register states
            States[typeof(BootstrapState)] = new BootstrapState(this, factoryContainer, coroutine, updateLoop);
            States[typeof(InitializeState)] = new InitializeState(this, factoryContainer, coroutine);
            States[typeof(LoadSceneState)] = new LoadSceneState(this, factoryContainer, coroutine);
            States[typeof(MenuState)] = new MenuState(this, factoryContainer);
            States[typeof(GameState)] = new GameState(this, factoryContainer, coroutine);
        }

        public void EnterState<TState>() where TState : IExitableState
        {
            Current?.Exit();
            var state = States[typeof(TState)];
            (state as IStateNext).Enter();
            Current = state;
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IExitableState
        {
            Current?.Exit();
            var state = States[typeof(TState)];
            (state as IStateWithArgument<TArgs>).Enter(args);
            Current = state;
        }
    }
}
