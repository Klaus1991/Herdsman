using System;
using Infrastructure.Factory;
using Infrastructure.States;
using Infrastructure.UnityContext.Components;
using UnityEngine;

namespace Infrastructure.UnityContext
{
    public class Initializer : ObjectContext
    {
        private void Awake() => Init();

        private void Init()
        {
            if (Exist())
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);

            // init state machine
            var stateMachine = new StateMachine(this, this, new FactoryContainer());
            stateMachine.EnterState<BootstrapState>();
        }

        private bool Exist()
        {
            var currentInitializer = ComponentLocator.Get<Initializer>();
            return currentInitializer != null && currentInitializer != this;
        }
    }
}

