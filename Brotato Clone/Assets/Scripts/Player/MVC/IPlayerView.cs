using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerView
    {
        void Move(Vector2 velocity);
    }
}