using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerModel
    {
        Vector2 CalculateVelocity(Vector2 inputDirection);
    }
}