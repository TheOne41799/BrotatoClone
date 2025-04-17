using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerView
    {
        void SetDependencies(IPlayerViewObserver playerController);
        void Move(Vector2 velocity);
    }
}