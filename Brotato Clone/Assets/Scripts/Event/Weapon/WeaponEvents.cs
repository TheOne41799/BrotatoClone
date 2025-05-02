using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class WeaponEvents
    {
        public IEventController<Action<DamageDisplayData>> OnEnemyHit {  get; private set; }
        public IEventController<Action<WeaponSpawnData>> OnWeaponCreated { get; private set; }

        public WeaponEvents()
        {
            OnEnemyHit = new DeferredEventController<Action<DamageDisplayData>>();
            OnWeaponCreated = new DeferredEventController<Action<WeaponSpawnData>>();
        }
    }
}