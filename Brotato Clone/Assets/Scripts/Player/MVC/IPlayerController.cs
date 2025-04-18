using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerController
    {
        void HandleMoveInput(Vector2 moveInput);
    }
}
