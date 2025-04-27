using BrotatoClone.Common;
using BrotatoClone.Event;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class WeaponManager : MonoBehaviour, IManager
    {
        private IEventManager eventManager;

        public void InitializeManager(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }
    }
}