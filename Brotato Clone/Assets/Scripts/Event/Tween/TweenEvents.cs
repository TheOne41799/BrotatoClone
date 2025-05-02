using BrotatoClone.Common;
using System;
using UnityEngine;

namespace BrotatoClone.Event
{
    public class TweenEvents
    {
        public IEventController<Action<TweenEventData>> OnTweenRequested {  get; private set; }

        public TweenEvents()
        {
            OnTweenRequested = new DeferredEventController<Action<TweenEventData>>();
        }
    }
}