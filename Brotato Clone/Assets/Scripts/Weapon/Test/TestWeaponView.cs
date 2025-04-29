using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class TestWeaponView : MonoBehaviour
    {
        [SerializeField] private Transform hitDetectionPoint;

        private TestWeaponController controller;

        private float hitDetectionRadius;
        private LayerMask layerMask;

        public void SetController(TestWeaponController controller)
        {
            this.controller = controller;
        }

        public Transform GetTransform() => this.transform;

        public void SetEnemyDetectionVariables(float hitDetectionRadius, LayerMask layerMask)
        {
            this .hitDetectionRadius = hitDetectionRadius;
            this .layerMask = layerMask;
        }

        public void Rotate(Quaternion quaternion, float rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, rotationSpeed * Time.deltaTime);
        }

        public void DetectEnemies()
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(hitDetectionPoint.position, hitDetectionRadius, layerMask);

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].TryGetComponent<IDamageable>(out var enemy))
                {
                    controller.DetectedEnemy(enemy);
                }
            }
        }



        //detect hitting the enemy
        //inform the controller
    }
}