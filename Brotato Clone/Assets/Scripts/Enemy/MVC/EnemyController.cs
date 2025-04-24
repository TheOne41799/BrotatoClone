using BrotatoClone.Common;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyController : IEnemyController
    {
        private IEnemyModel enemyModel;
        private IEnemyView enemyView;

        private ITarget target;

        private float moveSpeed = 2;

        public EnemyController(EnemyView enemyViewPrefab)
        {
            enemyModel = new EnemyModel(moveSpeed);
            enemyView = GameObject.Instantiate<EnemyView>(enemyViewPrefab, new Vector3(2, 2, 0), Quaternion.identity);
        }

        public void SetEnemyTarget(ITarget target)
        {
            this.target = target;
        }

        public void HandleFollowTarget()
        {
            if (target == null) return;

            Vector2 velocity = enemyModel.CalculateVelocity(target.TargetTransform.position, enemyView.GetPosition());
            enemyView.Move(velocity);
        }
    }
}