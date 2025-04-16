using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Player
{
    public class PlayerManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        public void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager;

            Debug.Log("Manager Dependencies are set");
        }
    }
}