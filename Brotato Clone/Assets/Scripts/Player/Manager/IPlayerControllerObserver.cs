using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerControllerObserver
    {
        void HandlePlayerStatus(Vector3 position);
    }
}