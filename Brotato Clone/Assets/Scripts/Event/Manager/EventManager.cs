using UnityEngine;

namespace BrotatoClone.Event
{
    public class EventManager: IEventManager
    {
        public InputEvents InputEvents { get; }
        public TweenEvents TweenEvents { get; }
        public PlayerEvents PlayerEvents { get; }

        public EventManager()
        {
            InputEvents = new InputEvents();
            TweenEvents = new TweenEvents();
            PlayerEvents = new PlayerEvents();
        }
    }
}