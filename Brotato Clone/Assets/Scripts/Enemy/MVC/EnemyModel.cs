using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyModel : IEnemyModel
    {
        private readonly float moveSpeed;
        private readonly float attackRange;
        private bool canMove;

        public EnemyModel(EnemyData enemyData)
        {
            this.moveSpeed = enemyData.MoveSpeed;
            this.attackRange = enemyData.AttackRange;

            canMove = false;
        }

        public void EnemyCanMove() => canMove = true;

        public Vector2 CalculateVelocity(Vector2 targetLocation, Vector2 enemyLocation)
        {
            if (!canMove) return Vector2.zero;

            Vector2 targetDirection = (targetLocation - enemyLocation).normalized;
            return targetDirection * moveSpeed;
        }

        public bool TryAttack(Vector2 targetLocation, Vector2 enemyLocation)
        {
            if(!canMove) return false;

            float distanceToPlayer = Vector2.Distance(targetLocation, enemyLocation);

            if (distanceToPlayer <= attackRange) return true;
            else return false;
        }        
    }
}