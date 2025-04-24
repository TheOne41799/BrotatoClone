using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyModel : IEnemyModel
{
        private float moveSpeed;

        public EnemyModel(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public Vector2 CalculateVelocity(Vector2 targetLocation, Vector2 enemyLocation)
        {
            Vector2 targetDirection = (targetLocation - enemyLocation).normalized;

            return targetDirection * moveSpeed;
        }
    }
}