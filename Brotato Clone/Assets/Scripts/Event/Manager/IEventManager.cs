using UnityEngine;

namespace BrotatoClone.Event
{
    public interface IEventManager
    {
        InputEvents InputEvents { get; }

        // Handle this later
        //TweenEvents TweenEvents { get; }
        PlayerEvents PlayerEvents { get; }
        EnemyEvents EnemyEvents { get; }
        WeaponEvents WeaponEvents { get; } 
    }
}