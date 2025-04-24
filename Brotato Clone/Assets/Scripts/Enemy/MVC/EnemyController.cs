using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Player;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyController : IEnemyController
    {
        private IEnemyModel enemyModel;
        private IEnemyView enemyView;

        private ITarget target;

        public EnemyController(EnemyData enemyData)
        {
            enemyModel = new EnemyModel(enemyData.MoveSpeed);
            enemyView = GameObject.Instantiate<EnemyView>(enemyData.EnemyViewPrefab, new Vector3(2, 2, 0), Quaternion.identity);
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