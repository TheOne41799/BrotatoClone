using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerInputController
    {
        Vector2 GetMovementVector();
    }
}