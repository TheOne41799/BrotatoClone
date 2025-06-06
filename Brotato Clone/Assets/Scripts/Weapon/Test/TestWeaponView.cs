using BrotatoClone.Common;
using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class TestWeaponView : MonoBehaviour
    {
        [SerializeField] private Transform hitDetectionPoint;
        [SerializeField] private Animator testWeaponAnimator;

        private TestWeaponController controller;

        private float hitDetectionRadius;
        private LayerMask layerMask;
        private float enemyDetectionRange;

        [Header("DEBUG")]
        [SerializeField] private bool isGizmosON;

        public void SetController(TestWeaponController controller)
        {
            this.controller = controller;
        }

        public Transform GetTestWeaponTransform() => this.transform;

        public Transform GetTransform() => this.transform;

        public void SetEnemyDetectionVariables(float hitDetectionRadius, LayerMask layerMask, float enemyDetectionRange)
        {
            this.hitDetectionRadius = hitDetectionRadius;
            this.layerMask = layerMask;
            this.enemyDetectionRange = enemyDetectionRange;
        }

        public void Rotate(Quaternion quaternion, float rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, rotationSpeed * Time.deltaTime);
        }

        //Does this belong here?
        public void DetectEnemies()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(hitDetectionPoint.position, hitDetectionRadius, layerMask);
            List<IDamageable> detectedEnemies = new List<IDamageable>();

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].TryGetComponent<IDamageable>(out var enemy))
                {
                    detectedEnemies.Add(enemy);
                }
            }

            controller.DetectedEnemies(detectedEnemies);
        }

        public void PlayAttackAnimation()
        {
            testWeaponAnimator.Play("Attack");

            //same value as attack rate
            //later get the variable and assign it
            //testWeaponAnimator.speed = 10f;
        }

        private void StopAttack()
        {
            controller.StopAttack();
        }

        private void OnDrawGizmos()
        {
            if (!isGizmosON) return;

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.transform.position, enemyDetectionRange);

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(hitDetectionPoint.position, hitDetectionRadius);
        }

        private void OnDisable()
        {
            controller?.ReleaseToPool();
        }
    }
}