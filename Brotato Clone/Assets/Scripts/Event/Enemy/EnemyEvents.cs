using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class EnemyEvents
    {
        public IEventController<Action<float>> OnApplyDamage {  get; private set; }
        public IEventController<Action<Vector2>> OnEnemyDeath { get; private set; } 

        public EnemyEvents()
        {
            OnApplyDamage = new DeferredEventController<Action<float>>();
            OnEnemyDeath = new DeferredEventController<Action<Vector2>>();
        }
    }
}