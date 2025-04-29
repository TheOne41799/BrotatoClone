using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class WeaponEvents
    {
        public IEventController<Action<Vector2>> OnEnemyHit {  get; private set; }

        public WeaponEvents()
        {
            OnEnemyHit = new EventController<Action<Vector2>>();
        }
    }
}