using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public interface IEnemyController
    {
        void CreateEnemy();
        void GetFromPool();
        void ReturnToPool();
        void DestroyFromPool();
        void SetEnemyTarget(ITarget target);
        void HandleFollowTarget();
        void HandleTryAttackTarget();
    }
}