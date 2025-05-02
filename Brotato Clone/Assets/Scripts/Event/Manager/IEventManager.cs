using UnityEngine;

namespace BrotatoClone.Event
{
    public interface IEventManager
    {
        GameEvents GameEvents { get; }
        InputEvents InputEvents { get; }

        // Handle this later
        //TweenEvents TweenEvents { get; }
        PlayerEvents PlayerEvents { get; }
        EnemyEvents EnemyEvents { get; }
        WeaponEvents WeaponEvents { get; } 
        WorldItemEvents WorldItemEvents { get; }
    }
}