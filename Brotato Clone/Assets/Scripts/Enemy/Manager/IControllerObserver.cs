using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IControllerObserver
    {
        void HandleApplyDamage(float damage);
        void OnEnemyDeath(Vector2 position);
    }
}