using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponView : MonoBehaviour, IWeaponView
    {
        protected IWeaponController weaponController;

        protected float detectionRadius;
        protected LayerMask enemyLayerMask;
        protected bool isGizmosON;

        protected virtual void Update()
        {
            DetectAndSendEnemies();
        }

        protected virtual void DetectAndSendEnemies()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayerMask);

            List<IDamageable> enemiesInRange = new List<IDamageable>();

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent<IDamageable>(out var enemy))
                {
                    enemiesInRange.Add(enemy);
                }
            }

            weaponController.OnEnemiesDetected(enemiesInRange);
        }

        public void SetController(IWeaponController controller)
        {
            weaponController = controller;
        }

        public virtual void InitializeView(float detectionRadius, LayerMask enemyLayerMask, bool isGizmosON)
        {
            this.detectionRadius = detectionRadius;
            this.enemyLayerMask = enemyLayerMask;
            this.isGizmosON = isGizmosON;
        }

        private void OnDrawGizmosSelected()
        {
            if (!isGizmosON) return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    }
}