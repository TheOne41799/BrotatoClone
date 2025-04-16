using UnityEngine;

namespace BrotatoClone.Common
{
    public interface IDependencyContainer
    {
        void Register<T>(T dependency);
        T Get<T>();
        void Unregister<T>();
    }
}