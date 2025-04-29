using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class TestWeaponModel
    {
        private TestWeaponController controller;
        private Transform viewTransform;
        
        private WeaponType weaponType;        
        private float enemyDetectionRange;
        private float rotationSpeed;
        private LayerMask layerMask;
        private float damage;
        private float hitDetectionRadius;

        public float HitDetectionRadius => hitDetectionRadius;
        public LayerMask LayerMask => layerMask;

        public TestWeaponModel(TestWeaponData testWeaponData)
        {
            this.weaponType = testWeaponData.WeaponType;
            this.enemyDetectionRange = testWeaponData.EnemyDetectionRange;
            this.rotationSpeed = testWeaponData.RotationSpeed;
            this.layerMask = testWeaponData.LayerMask;
            this.damage = testWeaponData.Damage;
            this.hitDetectionRadius = testWeaponData.HitDetectionRadius;
        }

        public void SetController(TestWeaponController controller)
        {
            this.controller = controller;
        }

        public void SetViewTransform(Transform viewTransform) => this.viewTransform = viewTransform;

        public void OnUpdate()
        {
            IDamageable closestEnemy = GetClosestEnemy();

            if (closestEnemy == null)
            {
                Rotate(Vector3.up);
                return;
            }

            Vector3 directionToEnemy = (closestEnemy.GetPosition() - (Vector2)viewTransform.position).normalized;
            Rotate(directionToEnemy);
        }

        private IDamageable GetClosestEnemy()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(viewTransform.position, 3f, layerMask);

            if (enemies.Length == 0) return null;

            IDamageable closestEnemy = null;
            float closestDistance = 3f;

            for (int i = 0; i < enemies.Length; i++)
            {
                Collider2D enemyCollider = enemies[i];
                if (enemyCollider.TryGetComponent<IDamageable>(out var enemy))
                {
                    float distance = Vector2.Distance(viewTransform.position, enemy.GetPosition());

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }

        public void Rotate(Vector3 targetDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);
            controller.Rotate(targetRotation, rotationSpeed);
        }

        public void Attack(IDamageable enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}