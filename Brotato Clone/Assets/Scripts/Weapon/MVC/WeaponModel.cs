using BrotatoClone.Common;
using BrotatoClone.Data;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponModel : IWeaponModel
    {
        /*private IWeaponModelObserver weaponController;

        protected WeaponType weaponType;
        protected float enemyDetectionRange;
        protected float rotationSpeed;
        protected LayerMask enemyLayerMask;
        protected bool isGizmosON;

        protected Transform weaponTransform;

        public WeaponType WeaponType => weaponType;
        public float EnemyDetectionRange => enemyDetectionRange;
        public float RotationSpeed => rotationSpeed;
        public LayerMask EnemyLayerMask => enemyLayerMask;
        public bool IsGizmosON => isGizmosON;

        public WeaponModel(WeaponData weaponData)
        {
            this.weaponType = weaponData.WeaponType;
            this.enemyDetectionRange = weaponData.EnemyDetectionRange;
            this.rotationSpeed = weaponData.RotationSpeed;
            this.enemyLayerMask = weaponData.LayerMask;
            this.isGizmosON = weaponData.IsGizmosON;
        }

        public void SetTransform(Transform weaponTransform)
        {
            this.weaponTransform = weaponTransform;
        }

        public void OnUpdate()
        {
            IDamageable closestEnemy = GetClosestEnemy();

            if(closestEnemy == null)
            {
                // call controller which will call view to rotate to default position which is upwards



                return;
            }

            Vector3 directionToEnemy = (closestEnemy.GetPosition() - (Vector2) weaponTransform.position).normalized;
            // call controller which will call view to rotate towards enemy
        }

        private IDamageable GetClosestEnemy()
        {
            Collider2D[] enemyColliders = Physics2D.OverlapCircleAll(weaponTransform.position, enemyDetectionRange, enemyLayerMask);

            if(enemyColliders.Length == 0) return null;

            IDamageable closestEnemy = null;
            float closestDistance = enemyDetectionRange;

            for (int i = 0; i < enemyColliders.Length; i++)
            {
                Collider2D enemyCollider = enemyColliders[i];

                if (enemyCollider.TryGetComponent<IDamageable>(out IDamageable enemy))
                {
                    float distance = Vector2.Distance(weaponTransform.position, enemy.GetPosition());
                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        closestEnemy = enemy;
                    }
                }
            }

            return closestEnemy;
        }        */
    }
}