using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class WeaponEvents
    {
        public IEventController<Action<DamageDisplayData>> OnEnemyHit {  get; private set; }

        public WeaponEvents()
        {
            OnEnemyHit = new EventController<Action<DamageDisplayData>>();
        }
    }
}