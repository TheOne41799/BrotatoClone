using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerController
    {
        void HandleMoveInput(Vector2 moveInput);
        void HandleTakeDamage(float damage);
        void HandleItemCollected(WorldItemCollected worldItemCollected);
    }
}
