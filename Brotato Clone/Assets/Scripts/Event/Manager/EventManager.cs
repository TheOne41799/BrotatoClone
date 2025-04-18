using UnityEngine;

namespace BrotatoClone.Event
{
    public class EventManager: IEventManager
    {
        public InputEvents InputEvents { get; }
        public PlayerEvents PlayerEvents { get; }

        public EventManager()
        {
            InputEvents = new InputEvents();
            PlayerEvents = new PlayerEvents();
        }
    }
}