using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerController
    {
        void HandleMoveInput(Vector2 moveInput);
        public void HandleTakeDamage(float damage);
    }
}
