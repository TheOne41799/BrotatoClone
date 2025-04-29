using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyModel
    {
        void SetController(IModelObserver enemyController);
        void EnemyCanMove();
        Vector2 CalculateVelocity(Vector2 targetLocation, Vector2 enemyLocation);
        bool TryAttack(Vector2 targetLocation, Vector2 enemyLocation);
        void Attack();
        void TakeDamage(float damage);
    }
}