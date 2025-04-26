using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerModelObserver
    {
        void HandleHealthUpdate(float health);
    }
}