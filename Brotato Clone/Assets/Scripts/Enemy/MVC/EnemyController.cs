using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Player;
using BrotatoClone.WorldItem;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyController : IEnemyController, IViewObserver, IModelObserver
    {
        private IControllerObserver enemyManager;
        private EnemyData enemyData;
        private IEnemyModel enemyModel;
        private IEnemyView enemyView;

        private ITarget target;

        private bool isDisposed;

        public EnemyController(EnemyData enemyData, IControllerObserver enemyManager)
        {
            this.enemyData = enemyData;
            this.enemyManager = enemyManager;
        }

        public void CreateEnemy()
        {
            enemyModel = new EnemyModel(enemyData);
            enemyModel.SetController(this);

            enemyView = GameObject.Instantiate<EnemyView>(enemyData.EnemyViewPrefab, new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0), Quaternion.identity);
            enemyView.SetController(this);
            enemyView.SetEnemyData(enemyData);
            enemyView.RunSpawnIndicatorTween();

            isDisposed = false;
        }

        public void GetFromPool()
        {
            enemyView.ToggleVisibility(true);
            isDisposed = false;
        }

        public void ReturnToPool()
        {
            enemyView.ToggleVisibility(false);
            isDisposed = true;
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
            if (isDisposed) return;

            Vector2 velocity = enemyModel.CalculateVelocity(target.TargetTransform.position, enemyView.GetPosition());
            enemyView.UpdateVelocity(velocity);
        }

        public void HandleTryAttackTarget()
        {
            if (isDisposed) return;

            bool canAttackPlayer = enemyModel.TryAttack(target.TargetTransform.position, enemyView.GetPosition());

            if(canAttackPlayer) HandleAttackTarget();

            /*if (canAttackPlayer)
            {                
                HandleAttackTarget();

                //enemyView.PlayDeathEffect();
                //OnDispose();
            }*/
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
            enemyView = null;
            target = null;

            // send a message to manager
        }

        public void TakeDamage(float damage)
        {
            enemyModel.TakeDamage(damage);
        }

        public void HandleEnemyDeath()
        {
            enemyManager.OnEnemyDeath(enemyView.GetPosition());
            enemyView.PlayDeathEffect();
            enemyView.DestroyEnemy();
            OnDispose();            
        }
    }
}