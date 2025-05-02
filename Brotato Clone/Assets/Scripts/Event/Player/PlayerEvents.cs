using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<ITarget>> OnTargetUpdated { get; private set; }
        public IEventController<Action<HealthDisplayData>> OnHealthUpdated { get; private set; }
        public IEventController<Action<XPDisplayData>> OnXPUpdated { get; private set; }
        public IEventController<Action<WeaponType>> OnWeaponRequested { get; private set; }

        public PlayerEvents()
        {
            OnTargetUpdated = new DeferredEventController<Action<ITarget>>();
            OnHealthUpdated = new DeferredEventController<Action<HealthDisplayData>>();
            OnXPUpdated = new DeferredEventController<Action<XPDisplayData>>();
            OnWeaponRequested = new DeferredEventController<Action<WeaponType>>();
        }
    }
}