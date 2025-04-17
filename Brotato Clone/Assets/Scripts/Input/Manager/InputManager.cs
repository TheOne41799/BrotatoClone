using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Input
{
    public class InputManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        public void SetManagerDependencies(IEventManager eventManager)
        {
            this.eventManager = eventManager; 
        }    
    }
}