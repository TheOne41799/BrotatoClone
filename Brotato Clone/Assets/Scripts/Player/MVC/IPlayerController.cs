using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerController
    {
        void HandleRequestWeapon();
        void HandleReceiveWeapon(WeaponSpawnData weaponSpawnData);
        void HandleMoveInput(Vector2 moveInput);
        void HandleTakeDamage(float damage);
        void HandleItemCollected(WorldItemCollected worldItemCollected);
    }
}
