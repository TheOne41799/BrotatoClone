using UnityEngine;

namespace BrotatoClone.Event
{
    public class EventManager: IEventManager
    {
        public InputEvents InputEvents { get; }

        // Handle this later
        //public TweenEvents TweenEvents { get; }

        public PlayerEvents PlayerEvents { get; }
        public EnemyEvents EnemyEvents { get; }
        public WeaponEvents WeaponEvents { get; }

        public EventManager()
        {
            InputEvents = new InputEvents();


            //TweenEvents = new TweenEvents();

            PlayerEvents = new PlayerEvents();
            EnemyEvents = new EnemyEvents();
            WeaponEvents = new WeaponEvents();
        }
    }
}