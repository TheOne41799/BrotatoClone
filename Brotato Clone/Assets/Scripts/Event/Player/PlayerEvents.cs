using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<ITarget>> OnCameraTargetCreated {  get; private set; }

        // create an event to indicate player has been destroyed or use the same event

        public PlayerEvents()
        {
            OnCameraTargetCreated = new EventController<Action<ITarget>>();
        }
    }
}