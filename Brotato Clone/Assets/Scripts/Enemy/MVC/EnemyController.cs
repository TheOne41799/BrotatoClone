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
            enemyModel = new EnemyModel(enemyData.MoveSpeed);

            enemyView = GameObject.Instantiate<EnemyView>(enemyData.EnemyViewPrefab, new Vector3(2, 2, 0), Quaternion.identity);
            enemyView.SetController(this);

            isDisposed = false;
        }

        public void SetEnemyTarget(ITarget target)
        {
            this.target = target;
        }

        public void HandleFollowTarget()
        {
            if (isDisposed) return;

            Vector2 velocity = enemyModel.CalculateVelocity(target.TargetTransform.position, enemyView.GetPosition());
            enemyView.Move(velocity);
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