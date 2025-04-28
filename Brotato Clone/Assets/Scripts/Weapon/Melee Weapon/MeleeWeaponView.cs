using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponView : WeaponView
    {
        [SerializeField] private Transform hitDetectionPoint;
        private float hitDetectionRadius = 0.3f;


        protected override void Update()
        {
            base.Update();
            Attack();
        }

        public void Attack()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(hitDetectionPoint.position, hitDetectionRadius, enemyMask);

            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].TryGetComponent<IDamageable>(out var enemy))
                {
                    Debug.Log("Enemy Hit");
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (!isGizmosON) return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hitDetectionPoint.position, hitDetectionRadius);
        }
    }
}