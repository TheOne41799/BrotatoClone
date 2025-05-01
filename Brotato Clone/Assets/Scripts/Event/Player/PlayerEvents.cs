using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<ITarget>> OnTargetUpdated {  get; private set; }
        public IEventController<Action<HealthDisplayData>> OnHealthUpdated { get; private set; }
        public IEventController<Action<XPDisplayData>> OnXPUpdated { get; private set; }
        public IEventController<Func<WeaponSpawnData>> OnWeaponRequested { get; private set; }

        // create an event to indicate player has been destroyed or use the same event

        public PlayerEvents()
        {
            OnTargetUpdated = new EventController<Action<ITarget>>();
            OnHealthUpdated = new EventController<Action<HealthDisplayData>>();
            OnXPUpdated = new EventController<Action<XPDisplayData>>();
            OnWeaponRequested = new EventController<Func<WeaponSpawnData>>();
        }
    }
}