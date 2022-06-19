using Herdsman.Models;
using Herdsman.UnityContext;
using Infrastructure.States;
using Infrastructure.UnityContext;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Logic
{
    public class GroupState : IStateWithArgument<PlayerActor>
    {
        private readonly NavMeshAgent Agent;
        private readonly IStateMachine StateMachine;
        private readonly ICollideWithYard CollideEvent;
        private readonly float MoveSpeed;
        private readonly IUpdateLoop UnityUpdater;
        private readonly IMovable Movable;

        private PlayerActor Player { get; set; }

        public GroupState(NavMeshAgent agent, float speed, ICollideWithYard events, IUpdateLoop updateLoop, IMovable movable, IStateMachine stateMachine)
        {
            Agent = agent;
            StateMachine = stateMachine;
            CollideEvent = events;
            UnityUpdater = updateLoop;
            Movable = movable;
            MoveSpeed = speed;
        }

        public void Enter(PlayerActor player)
        {
            Player = player;
            Agent.speed = MoveSpeed;
            CollideEvent.OnCollideYard += OnCollideWithYard;
            UnityUpdater.OnUpdate += OnUpdate;
        }

        public void Exit()
        {
            CollideEvent.OnCollideYard -= OnCollideWithYard;
            UnityUpdater.OnUpdate -= OnUpdate;
            Player.LeaveGroup(Movable as BaseActor);
        }

        // events
        private void OnCollideWithYard()
        {
            StateMachine.EnterState<PatrolState, bool>(true);
        }

        private void OnUpdate()
        {
            if (Player == null)
                return;
            Movable.MoveTo(Player.Position);
        }
    }
}
