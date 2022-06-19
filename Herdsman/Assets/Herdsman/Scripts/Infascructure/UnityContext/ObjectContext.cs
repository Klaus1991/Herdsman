using System;
using UnityEngine;

namespace Infrastructure.UnityContext
{
    public class ObjectContext : MonoBehaviour, ICoroutineRunner, IUpdateLoop
    {
        public event Action OnUpdate;

        private void Update() => OnUpdate?.Invoke();
    }
}
