

using Herdsman.Logic;
using Herdsman.UnityContext;
using Infrastructure.States;
using Infrastructure.UnityContext;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Models
{
    public class AnimalActor : BaseActor, IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> States;
        private readonly ICollideWithPlayer CollideEvent;
        private readonly ICollideWithYard YardEvent;
        private readonly IUpdateLoop Updater;
        private readonly ICoroutineRunner CoroutineRunner;
        private IExitableState Current { get; set; }
        private ISetColor ColorSwitcher { get; set; }

        public AnimalActor(GameObject viewObject, float speed, Vector2 patrolTime) : base(viewObject, speed)
        {
            CollideEvent = View.GetComponent<ICollideWithPlayer>();
            YardEvent = View.GetComponent<ICollideWithYard>();
            Updater = View.GetComponent<IUpdateLoop>();
            ColorSwitcher = View.GetComponent<ISetColor>();
            CoroutineRunner = View.GetComponent<ICoroutineRunner>();
            States = new Dictionary<Type, IExitableState>();
            // register states
            States[typeof(IdleState)] = new IdleState(Agent, patrolTime, CoroutineRunner, CollideEvent, this);
            States[typeof(GroupState)] = new GroupState(Agent, speed, YardEvent, Updater, this, this);
            States[typeof(PatrolState)] = new PatrolState(Agent, speed, patrolTime, CoroutineRunner, this, this);
        }

        public void EnterState<TState>() where TState : IExitableState
        {
            Current?.Exit();
            var state = States[typeof(TState)];
            (state as IStateNext).Enter();
            Current = state;
            ColorSwitcher?.SetStateColor(Current);
        }

        public void EnterState<TState, TArgs>(TArgs args) where TState : IExitableState
        {
            Current?.Exit();
            var state = States[typeof(TState)];
            (state as IStateWithArgument<TArgs>).Enter(args);
            Current = state;
            ColorSwitcher?.SetStateColor(Current);
        }
    }
}
