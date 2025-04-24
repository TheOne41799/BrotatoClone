using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<ITarget>> OnTargetCreated {  get; private set; }

        // create an event to indicate player has been destroyed or use the same event

        public PlayerEvents()
        {
            OnTargetCreated = new EventController<Action<ITarget>>();
        }
    }
}