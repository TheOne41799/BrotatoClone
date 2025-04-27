using UnityEngine;

namespace BrotatoClone.Player
{
    public interface IPlayerModel
    {
        void SetController(IPlayerModelObserver playerController);
        Vector2 CalculateVelocity(Vector2 inputDirection);
        public void TakeDamage(float damage);
    }
}