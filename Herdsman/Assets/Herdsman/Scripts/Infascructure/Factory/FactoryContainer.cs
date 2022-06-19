using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class FactoryContainer : IFactoryContainer
    {
        private readonly Dictionary<Type, IFactory> Container;

        public FactoryContainer()
        {
            Container = new Dictionary<Type, IFactory>();
        }

        public IFactory Register<TFactory>(IFactory factory) where TFactory : IFactory
        {
            var type = typeof(TFactory);
            Container[type] = factory;
            factory.OnRegister(this);
            return factory;
        }

        public TFactory Get<TFactory>() where TFactory : IFactory
        {
            var type = typeof(TFactory);
            if (Container.ContainsKey(type))
                return (TFactory)Container[type];
            return default;
        }
    }
}
