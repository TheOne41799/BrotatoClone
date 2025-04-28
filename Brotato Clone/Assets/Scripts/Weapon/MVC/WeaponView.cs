using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponView : MonoBehaviour, IWeaponView
    {
        [SerializeField] protected LayerMask enemyMask;
        [SerializeField] private float rotationSpeed = 12f;

        [Header("DEBUG")]
        [SerializeField] protected bool isGizmosON;

        protected virtual void Update()
        {
            IDamageable closestEnemy = GetClosestEnemy();

            if (closestEnemy == null)
            {
                RotateTowards(Vector3.up);
                return;
            }

            Vector3 directionToEnemy = (closestEnemy.GetPosition() - (Vector2)transform.position).normalized;
            RotateTowards(directionToEnemy);
        }

        private IDamageable GetClosestEnemy()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(this.transform.position, 3f, enemyMask);

            if (enemies.Length == 0) return null;

            IDamageable closestEnemy = null;
            float closestDistance = 3f;

            for (int i = 0; i < enemies.Length; i++)
            {
                Collider2D enemyCollider = enemies[i];
                if (enemyCollider.TryGetComponent<IDamageable>(out var enemy))
                {
                    float distance = Vector2.Distance(transform.position, enemy.GetPosition());

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }

        private void RotateTowards(Vector3 targetDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }



        private void OnDrawGizmos()
        {
            if (!isGizmosON) return;

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(this.transform.position, 3f);
        }
    }
}