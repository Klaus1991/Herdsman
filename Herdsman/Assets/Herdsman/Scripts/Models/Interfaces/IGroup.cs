using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Models
{
    public interface IGroup
    {
        event Action<BaseActor> OnActorLeave;

        List<BaseActor> Group { get; }

        bool JoinGroup(BaseActor actor);

        void LeaveGroup(BaseActor actor);
    }
}
