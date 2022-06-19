
using System;
using System.Collections.Generic;
using Herdsman.Logic;
using Herdsman.UnityContext;
using UnityEngine;
using UnityEngine.AI;

namespace Herdsman.Models
{
    public class PlayerActor : BaseActor, IGroup
    {
        private readonly int MaxGroupSize;

        public event Action<BaseActor> OnActorLeave;

        public List<BaseActor> Group { get; private set; }

        public PlayerActor(GameObject viewObject, float speed, int maxGroupSize) : base(viewObject, speed)
        {
            MaxGroupSize = maxGroupSize;
            Group = new List<BaseActor>();
            InjectDependencies();
        }

        public bool JoinGroup(BaseActor actor)
        {
            var groupSize = Group.Count;
            var isFull = groupSize >= MaxGroupSize;
            if (!isFull)
            {
                if (!Group.Contains(actor))
                    Group.Add(actor);
            }
            return !isFull;
        }

        public void LeaveGroup(BaseActor actor)
        {
            if (Group.Contains(actor))
            {
                Group.Remove(actor);
                OnActorLeave?.Invoke(actor);
            }
        }

        private void InjectDependencies()
        {
            foreach (var dep in View.GetComponents<ISetPlayer>())
                dep.SetPlayer(this);
        }
    }
}

