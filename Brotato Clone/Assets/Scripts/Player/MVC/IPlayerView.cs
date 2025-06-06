using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerView
    {
        void UpdateVelocity(Vector2 velocity);
        void AddWeapon(WeaponSpawnData weaponSpawnData);
    }
}