using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<ITarget>> OnTargetUpdated {  get; private set; }
        public IEventController<Action<float>> OnHealthUpdated { get; private set; }

        // create an event to indicate player has been destroyed or use the same event

        public PlayerEvents()
        {
            OnTargetUpdated = new EventController<Action<ITarget>>();
            OnHealthUpdated = new EventController<Action<float>>();
        }
    }
}