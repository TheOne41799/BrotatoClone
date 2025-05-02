using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class InputEvents
    {
        public IEventController<Action<Vector2>> OnMoveInput {  get; }

        public InputEvents()
        {
            OnMoveInput = new DeferredEventController<Action<Vector2>>();
        }
    }
}