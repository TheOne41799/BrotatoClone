using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerModelObserver
    {
        void HandleHealthUpdate(HealthDisplayData healthDisplayData);
    }
}