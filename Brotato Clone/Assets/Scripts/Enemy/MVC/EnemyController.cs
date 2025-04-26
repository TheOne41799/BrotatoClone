using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyController : IEnemyController, IViewObserver
    {
        private IEnemyModel enemyModel;
        private IEnemyView enemyView;

        private ITarget target;

        private bool isDisposed;

        public EnemyController(EnemyData enemyData)
        {
            enemyModel = new EnemyModel(enemyData);

            enemyView = GameObject.Instantiate<EnemyView>(enemyData.EnemyViewPrefab, new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0), Quaternion.identity);
            enemyView.SetController(this);
            enemyView.SetEnemyData(enemyData);
            enemyView.RunSpawnIndicatorTween();

            isDisposed = false;
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

        public void OnDispose()
        {
            isDisposed = true;

            enemyModel = null;
            enemyView = null;
            target = null;

            // send a message to manager
        }
    }
}