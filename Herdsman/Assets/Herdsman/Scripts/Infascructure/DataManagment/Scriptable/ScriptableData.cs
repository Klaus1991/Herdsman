using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Data.Scriptable
{
    public abstract class ScriptableData : ScriptableObject
    {
        private static Dictionary<Type, ScriptableData> Cache { get; set; } = new Dictionary<Type, ScriptableData>();

        protected virtual IDataProvider<ScriptableObject> DataProvider { get; private set; } = new ResourcesDataProvider();

        public abstract string DataPath { get; }

        internal virtual T Load<T>() where T : ScriptableData
        {
            return DataProvider.Load<T>(DataPath);
        }

        public static T Get<T>() where T : ScriptableData, new()
        {
            var type = typeof(T);
            bool containData = Cache.ContainsKey(type);
            if (containData)
            {
                return (T)Cache[type];
            }
            else
            {
                var newData = new T().Load<T>();
                Cache[type] = newData;
                return newData;
            }
        }

        public void Save()
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }
}
