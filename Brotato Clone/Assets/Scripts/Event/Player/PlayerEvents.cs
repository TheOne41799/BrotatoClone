using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class PlayerEvents
    {
        public IEventController<Action<Vector3>> OnPlayerStatusUpdated {  get; private set; }
    }
}