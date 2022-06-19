using Herdsman.Logic;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Models
{
    public abstract class BaseActor : IMovable
    {
        public GameObject View { get; private set; }

        protected NavMeshAgent Agent { get; private set; }

        public Vector3 Position => View.transform.position;

        public BaseActor(GameObject viewObject, float PlayerSpeed)
        {
            View = viewObject;
            Agent = viewObject.GetComponent<NavMeshAgent>();
            // set speed
            Agent.speed = PlayerSpeed;
        }

        public virtual void MoveTo(Vector3 position)
        {
            Agent.destination = position;
        }
    }
}
