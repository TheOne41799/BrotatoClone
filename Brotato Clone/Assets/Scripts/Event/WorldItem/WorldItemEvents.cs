using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class WorldItemEvents
    {
        public IEventController<Action<WorldItemCollected>> OnItemCollected {  get; private set; }

        public WorldItemEvents()
        {
            OnItemCollected = new DeferredEventController<Action<WorldItemCollected>>();
        }
    }
}