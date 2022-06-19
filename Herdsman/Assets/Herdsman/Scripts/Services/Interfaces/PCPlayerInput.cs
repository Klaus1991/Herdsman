using Infrastructure.UnityContext;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herdsman.Services
{
    public class PCPlayerInput : IPlayerInput
    {
        private readonly IUpdateLoop UnityUpdater;

        public event Action<Vector2> OnClickEvent;

        public PCPlayerInput(IUpdateLoop updateLoop)
        {
            UnityUpdater = updateLoop;
            UnityUpdater.OnUpdate += OnUpdateEvent;
        }

        private void OnUpdateEvent()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClickEvent?.Invoke(Input.mousePosition);
            }
        }
    }
}
