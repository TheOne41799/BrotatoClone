using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerModel
    {
        void SetController(IPlayerModelObserver playerController);
        void InitModel();
        Vector2 CalculateVelocity(Vector2 inputDirection);
        void TakeDamage(float damage);
        void HandleItemCollected(WorldItemCollected worldItemCollected);
    }
}