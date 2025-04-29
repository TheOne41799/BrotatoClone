using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Enemy
{
    public class EnemyModel : IEnemyModel
    {
        private IModelObserver enemyController;

        private readonly float moveSpeed;
        private readonly float attackRange;
        private readonly float attackDamage;
        private readonly float attackRate;
        private readonly float attackDelay;
        private float currentHealth;
        private float attackTimer;
        private bool canMove;

        public EnemyModel(EnemyData enemyData)
        {
            this.moveSpeed = enemyData.MoveSpeed;
            this.attackRange = enemyData.AttackRange;
            this.attackDamage = enemyData.AttackDamage;
            this.attackRate = enemyData.AttackRate;
            this.currentHealth = enemyData.MaxHealth;
            
            this.attackDelay = 1f / this.attackRate;
            this.canMove = false;
            this.attackTimer = 0f;
        }

        public void SetController(IModelObserver enemyController)
        {
            this.enemyController = enemyController;
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
            if (!canMove) return false;

            if (attackTimer >= attackDelay)
            {
                float distanceToPlayer = Vector2.Distance(targetLocation, enemyLocation);

                if (distanceToPlayer <= attackRange)
                {
                    attackTimer = 0;
                    return true;
                }
                else return false;
            }
            else
            {
                attackTimer += Time.deltaTime;
                return false;
            }
        }

        public void Attack()
        {          
            enemyController.HandleApplyDamage(attackDamage);
        }

        public void TakeDamage(float damage)
        {
            if(!canMove) return;

            float adjustedDamage = Mathf.Min(damage, currentHealth);
            currentHealth -= adjustedDamage;

            if (this.currentHealth <= 0) enemyController.HandleEnemyDeath();
        }
    }
}