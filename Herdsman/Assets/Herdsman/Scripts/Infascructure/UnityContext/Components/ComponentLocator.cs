using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.UnityContext.Components
{
    public class ComponentLocator : MonoBehaviour
    {
        private const string LOCATOR_NAME = "[ComponentLocator]";

        private static ComponentLocator current;
        private static ComponentLocator Current
        {
            get
            {
                if (current == null)
                {
                    var locatorObject = new GameObject(LOCATOR_NAME);
                    current = locatorObject.AddComponent<ComponentLocator>();
                }
                return current;
            }
        }

        public static TComponent Get<TComponent>() where TComponent : MonoBehaviour
        {
            return Current.InternalGet<TComponent>();
        }

        private readonly Dictionary<Type, MonoBehaviour> ComponentCache = new Dictionary<Type, MonoBehaviour>();

        internal TComponent InternalGet<TComponent>() where TComponent : MonoBehaviour
        {
            var type = typeof(TComponent);
            var contatinCache = ComponentCache.ContainsKey(type);
            if (contatinCache)
            {
                return (TComponent)ComponentCache[type];
            }
            else
            {
                var component = FindObjectOfType<TComponent>();
                if (component != null)
                {
                    ComponentCache[type] = component;
                }
                return component;
            }
        }
    }
}
