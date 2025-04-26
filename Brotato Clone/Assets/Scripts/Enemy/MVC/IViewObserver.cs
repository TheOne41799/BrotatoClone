using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IViewObserver
    {
        void OnSpawnSequenceCompleted();
        void OnDispose();
    }
}