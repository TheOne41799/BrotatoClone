using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyView
    {
        void SetController(IViewObserver enemyController);
        void ToggleVisibility(bool visibility);
        void SetEnemyData(EnemyData enemyData);
        void RunSpawnIndicatorTween();
        Vector2 GetPosition();
        void UpdateVelocity(Vector2 velocity);
        void PlayDeathEffect();
        void DestroyEnemy();
    }
}