using Herdsman.Models;
using Herdsman.UnityContext;
using Herdsman.Utils;
using Infrastructure.States;
using Infrastructure.UnityContext;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Logic
{
    public class PatrolState : IStateWithArgument<bool>
    {
        private readonly NavMeshAgent Agent;
        private readonly IStateMachine StateMachine;
        private readonly IMovable Movable;
        private readonly ICoroutineRunner CoroutineRunner;
        private readonly Vector2 PatrolTime;
        private readonly float MoveSpeed;
        private readonly float RandomPathArea = 15f;

        public bool IsIsYard { get; private set; }
        private Coroutine LoopCoroutine { get; set; }
        private Coroutine ToIdleCoroutine { get; set; }

        public PatrolState(NavMeshAgent agent, float speed, Vector2 ToIdleTime, ICoroutineRunner coroutineRunner, IMovable movable, IStateMachine stateMachine)
        {
            Agent = agent;
            StateMachine = stateMachine;
            CoroutineRunner = coroutineRunner;
            Movable = movable;
            MoveSpeed = speed;
            PatrolTime = ToIdleTime;
        }

        public void Enter(bool isYard)
        {
            Agent.speed = MoveSpeed;
            IsIsYard = isYard;
            LoopCoroutine = CoroutineRunner.StartCoroutine(PatrolLoop());
            if (!isYard)
            {
                ToIdleCoroutine = CoroutineRunner.StartCoroutine(ToIdleState());
            }
        }

        public void Exit()
        {
            if (LoopCoroutine != null)
                CoroutineRunner.StopCoroutine(LoopCoroutine);
            if (ToIdleCoroutine != null)
                CoroutineRunner.StopCoroutine(ToIdleCoroutine);
        }

        private IEnumerator PatrolLoop()
        {
            SetRandomPath();
            while (true)
            {
                yield return null;
                if (Agent.velocity.magnitude == 0)
                {
                    SetRandomPath();
                }
            }
        }

        private IEnumerator ToIdleState()
        {
            var toIdleTime = Random.Range(PatrolTime.x, PatrolTime.y);
            yield return new WaitForSeconds(toIdleTime);
            StateMachine.EnterState<IdleState>();
        }

        private void SetRandomPath()
        {
            var area = IsIsYard ? NavmeshUtils.YardArea : NavmeshUtils.FieldArea;
            var newPosition = NavmeshUtils.RandomNavmeshLocation(Movable.Position, RandomPathArea, area);
            Movable.MoveTo(newPosition);
        }
    }
}
