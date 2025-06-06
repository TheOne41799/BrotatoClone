using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyView
    {
        void SetController(IViewObserver enemyController);
        void SetEnemyData(EnemyData enemyData);
        void RunSpawnIndicatorTween();
        Vector2 GetPosition();
        void UpdateVelocity(Vector2 velocity);
        void PlayDeathEffect();
        void DestroyEnemy();
    }
}