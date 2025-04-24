using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyModel : IEnemyModel
{
        private readonly float moveSpeed;
        private readonly float attackRange;

        public EnemyModel(EnemyData enemyData)
        {
            this.moveSpeed = enemyData.MoveSpeed;
            this.attackRange = enemyData.AttackRange;
        }

        public Vector2 CalculateVelocity(Vector2 targetLocation, Vector2 enemyLocation)
        {
            Vector2 targetDirection = (targetLocation - enemyLocation).normalized;

            return targetDirection * moveSpeed;
        }

        public bool TryAttack(Vector2 targetLocation, Vector2 enemyLocation)
        {
            float distanceToPlayer = Vector2.Distance(targetLocation, enemyLocation);

            if (distanceToPlayer <= attackRange)
            {                
                return true;
            }
            else
            {
                return false;
            }
        }        
    }
}