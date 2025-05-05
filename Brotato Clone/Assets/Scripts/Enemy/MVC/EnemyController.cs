using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Player;
using BrotatoClone.WorldItem;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyController
    {
        private EnemyManager enemyManager;
        private EnemyData enemyData;
        private EnemyModel enemyModel;
        private EnemyView enemyView;

        private ITarget target;

        private bool isDisposed;

        public EnemyController(EnemyData enemyData, EnemyManager enemyManager)
        {
            this.enemyData = enemyData;
            this.enemyManager = enemyManager;
        }

        public void CreateEnemy()
        {
            enemyModel = new EnemyModel(enemyData);
            enemyModel.SetController(this);

            enemyView = GameObject.Instantiate<EnemyView>(enemyData.EnemyViewPrefab, new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0), Quaternion.identity, enemyManager.transform);
            enemyView.SetController(this);
            enemyView.SetEnemyData(enemyData);
            enemyView.RunSpawnIndicatorTween();

            isDisposed = false;
        }

        public void GetFromPool()
        {
            enemyView.ToggleVisibility(true);
            isDisposed = false;

            enemyModel = new EnemyModel(enemyData);
            enemyModel.SetController(this);
        }

        public void ReturnToPool()
        {
            enemyView.ToggleVisibility(false);
            isDisposed = true;
            target = null;
        }

        public void DestroyFromPool()
        {
            OnDispose();
        }

        public void SetEnemyTarget(ITarget target)
        {
            this.target = target;
        }

        public void OnSpawnSequenceCompleted()
        {
            enemyModel.EnemyCanMove();
        }

        public void HandleFollowTarget()
        {
            if (isDisposed || target == null) return;

            Vector2 velocity = enemyModel.CalculateVelocity(target.TargetTransform.position, enemyView.GetPosition());
            enemyView.UpdateVelocity(velocity);
        }

        public void HandleTryAttackTarget()
        {
            if (isDisposed || target == null) return;

            if (enemyModel.TryAttack(target.TargetTransform.position, enemyView.GetPosition()))
            {
                HandleAttackTarget();
            }
        }

        private void HandleAttackTarget()
        {
            enemyModel.Attack();
        }

        public void HandleApplyDamage(float damage)
        {
            enemyManager.HandleApplyDamage(damage);
        }

        public void OnDispose()
        {
            isDisposed = true;

            enemyModel = null;
            target = null;
        }

        public void TakeDamage(float damage)
        {
            enemyModel.TakeDamage(damage);
        }

        public void HandleEnemyDeath()
        {
            enemyManager.OnEnemyDeath(enemyView.GetPosition());
            enemyView.PlayDeathEffect();
            enemyManager.ReleaseEnemy(this);
        }
    }
}