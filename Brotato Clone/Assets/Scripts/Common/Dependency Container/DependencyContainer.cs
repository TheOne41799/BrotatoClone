using System.Collections.Generic;
using UnityEngine;
using System;

namespace BrotatoClone.Common
{
    public class DependencyContainer: IDependencyContainer
    {
        private Dictionary<Type, object> dependencies = new Dictionary<Type, object>();

        public void Register<T>(T dependency)
        {
            dependencies[typeof(T)] = dependency;
        }

        public T Get<T>()
        {
            if(dependencies.TryGetValue(typeof(T), out object dependency))
            {
                return (T)dependency;
            }
            else
            {
                Debug.LogError($"[DependencyContainer] Service of type {typeof(T).Name} is not registered");
                return default;
            }
        }

        public void Unregister<T>()
        {
            if (dependencies.ContainsKey(typeof(T)))
            {
                dependencies[typeof (T)] = null;
            }
            else
            {
                Debug.LogError($"[DependencyContainer] Attempted to unregister {typeof(T).Name}, but it wasn't registered.");
            }
        }
    }
}