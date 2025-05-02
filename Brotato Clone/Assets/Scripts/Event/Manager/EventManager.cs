using UnityEngine;

namespace BrotatoClone.Event
{
    public class EventManager: IEventManager
    {
        public GameEvents GameEvents {  get; }
        public InputEvents InputEvents { get; }
        public PlayerEvents PlayerEvents { get; }
        public EnemyEvents EnemyEvents { get; }
        public WeaponEvents WeaponEvents { get; }
        public WorldItemEvents WorldItemEvents { get; }

        public EventManager()
        {
            GameEvents = new GameEvents();
            InputEvents = new InputEvents();
            PlayerEvents = new PlayerEvents();
            EnemyEvents = new EnemyEvents();
            WeaponEvents = new WeaponEvents();
            WorldItemEvents = new WorldItemEvents();
        }
    }
}