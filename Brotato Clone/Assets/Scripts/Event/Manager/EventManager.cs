using UnityEngine;

namespace BrotatoClone.Event
{
    public class EventManager: IEventManager
    {
        public InputEvents InputEvents { get; }

        public EventManager()
        {
            InputEvents = new InputEvents();
        }
    }
}