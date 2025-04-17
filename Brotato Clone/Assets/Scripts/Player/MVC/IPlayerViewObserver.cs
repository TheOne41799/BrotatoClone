using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerViewObserver
    {
        void HandlePlayerStatus(Vector3 position);
    }
}