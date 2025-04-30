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
            OnApplyDamage = new EventController<Action<float>>();
            OnEnemyDeath = new EventController<Action<Vector2>>();
        }
    }
}