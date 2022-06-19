using System;
using System.Collections;
using System.Collections.Generic;
using Herdsman.Models;
using Infrastructure.UnityContext;
using UnityEngine;

namespace Herdsman.UnityContext
{
    public class AnimalUnityContext : MonoBehaviour, ICollideWithPlayer, ICollideWithYard, IUpdateLoop, ICoroutineRunner
    {
        public event Action<PlayerActor> OnCollidePlayer;
        public event Action OnCollideYard;
        public event Action OnUpdate;

        public void ColliderWithPlayer(PlayerActor playerActor)
        {
            OnCollidePlayer?.Invoke(playerActor);
        }

        public void CollidWithYard()
        {
            OnCollideYard?.Invoke();
        }

        private void Update() => OnUpdate?.Invoke();
    }
}