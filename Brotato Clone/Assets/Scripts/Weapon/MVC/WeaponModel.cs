using BrotatoClone.Common;
using BrotatoClone.Data;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponModel : IWeaponModel
    {
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

        public void SetTransform(Transform transform)
        {
            this.weaponTransform = transform;
        }

        public abstract void Attack(List<IDamageable> enemiesInRange);

        protected IDamageable GetClosestEnemy(List<IDamageable> enemies)
        {
            if (enemies == null || enemies.Count == 0) return null;

            IDamageable closestEnemy = null;
            float closestDistance = enemyDetectionRange;

            foreach (var enemy in enemies)
            {
                if (enemy == null) continue;

                float distance = Vector2.Distance(weaponTransform.position, enemy.GetPosition());

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}