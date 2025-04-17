using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class InputEvents
    {
        public EventController<Action<Vector2>> OnMoveInput {  get; }

        public InputEvents()
        {
            OnMoveInput = new EventController<Action<Vector2>>();
        }
    }
}