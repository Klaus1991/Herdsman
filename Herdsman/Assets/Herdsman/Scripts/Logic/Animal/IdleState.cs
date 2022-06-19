using Herdsman.Models;
using Herdsman.UnityContext;
using Infrastructure.States;
using Infrastructure.UnityContext;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Logic
{
    public class IdleState : IStateNext
    {
        private readonly NavMeshAgent Agent;
        private readonly IStateMachine StateMachine;
        private readonly ICollideWithPlayer CollideEvent;
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly Vector2 IdleTime;

        private Coroutine ToPatrolCoroutine { get; set; }

        public IdleState(NavMeshAgent agent, Vector2 ToPatrolTime, ICoroutineRunner coroutineRunner, ICollideWithPlayer events, IStateMachine stateMachine)
        {
            Agent = agent;
            StateMachine = stateMachine;
            CollideEvent = events;
            CoroutineRunner = coroutineRunner;
            IdleTime = ToPatrolTime;
        }

        public void Enter()
        {
            Agent.speed = 0;
            CollideEvent.OnCollidePlayer += OnCollideWithPlayer;
            ToPatrolCoroutine = CoroutineRunner.StartCoroutine(ToPatrolState());
        }

        public void Exit()
        {
            CollideEvent.OnCollidePlayer -= OnCollideWithPlayer;
            if (ToPatrolCoroutine != null)
                CoroutineRunner.StopCoroutine(ToPatrolCoroutine);
        }

        private IEnumerator ToPatrolState()
        {
            var toPatrolTime = Random.Range(IdleTime.x, IdleTime.y);
            yield return new WaitForSeconds(toPatrolTime);
            StateMachine.EnterState<PatrolState, bool>(false);
        }

        // events
        private void OnCollideWithPlayer(PlayerActor playerActor)
        {
            var result = playerActor.JoinGroup(StateMachine as BaseActor);
            if (result)
                StateMachine.EnterState<GroupState, PlayerActor>(playerActor);
        }
    }
}
