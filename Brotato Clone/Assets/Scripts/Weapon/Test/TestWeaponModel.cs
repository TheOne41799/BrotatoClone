using BrotatoClone.Common;
using BrotatoClone.Data;
using System.Collections.Generic;
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
        private float attackRate;
        private float attackDelay;
        private float attackTimer;

        public float HitDetectionRadius => hitDetectionRadius;
        public LayerMask LayerMask => layerMask;

        private WeaponAnimationState weaponAnimationState;

        private List<IDamageable> detectedEnemies;
        private HashSet<IDamageable> damagedEnemies;

        public TestWeaponModel(TestWeaponData testWeaponData)
        {
            this.weaponType = testWeaponData.WeaponType;
            this.enemyDetectionRange = testWeaponData.EnemyDetectionRange;
            this.rotationSpeed = testWeaponData.RotationSpeed;
            this.layerMask = testWeaponData.LayerMask;
            this.damage = testWeaponData.Damage;
            this.hitDetectionRadius = testWeaponData.HitDetectionRadius;
            this.attackRate = testWeaponData.AttackRate;

            this.attackDelay = 1f/ this.attackRate;
            this.attackTimer = 0f;

            weaponAnimationState = WeaponAnimationState.IDLE;
            detectedEnemies = new List<IDamageable>();
            damagedEnemies = new HashSet<IDamageable>();
        }

        public void SetController(TestWeaponController controller)
        {
            this.controller = controller;
        }

        public void SetViewTransform(Transform viewTransform) => this.viewTransform = viewTransform;

        public void SetDetectedEnemies(List<IDamageable> enemies)
        {
            detectedEnemies = enemies;
        }

        public void OnUpdate()
        {
            attackTimer += Time.deltaTime;

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
            Collider2D[] enemies = Physics2D.OverlapCircleAll(viewTransform.position, enemyDetectionRange, layerMask);

            if (enemies.Length == 0) return null;

            IDamageable closestEnemy = null;
            float closestDistance = enemyDetectionRange;

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
            switch(weaponAnimationState)
            {
                case WeaponAnimationState.IDLE:
                    StartAttack();
                    break;
                case WeaponAnimationState.ATTACK:
                    Attacking(enemy);
                    break;
            }
        }

        private void StartAttack()
        {
            controller.PlayAttackAnimation();
            weaponAnimationState = WeaponAnimationState.ATTACK;
        }

        private void Attacking(IDamageable enemy)
        {
            if (attackTimer >= attackDelay)
            {
                if (!damagedEnemies.Contains(enemy))
                {
                    enemy.TakeDamage(damage);
                    DamageDisplayData damageDisplayData = new DamageDisplayData(enemy.GetDamageTextSpawnPosition(), damage);
                    //controller.HandleEnemyHit(enemy.GetDamageTextSpawnPosition());
                    controller.HandleEnemyHit(damageDisplayData);
                    damagedEnemies.Add(enemy);
                    attackTimer = 0f;
                }
            }
        }

        public void StopAttack()
        {
            weaponAnimationState = WeaponAnimationState.IDLE;

            damagedEnemies.Clear();
        }        
    }
}