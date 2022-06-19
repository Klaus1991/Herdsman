using Herdsman.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public interface ICollideWithPlayer
    {
        event Action<PlayerActor> OnCollidePlayer;

        void ColliderWithPlayer(PlayerActor playerActor);
    }
}
