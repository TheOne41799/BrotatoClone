using BrotatoClone.Common;
using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponModel : WeaponModel
    {
        private float damage;
        private float hitDetectionRadius;

        public float Damage => damage;
        public float HitDetectionRadius => hitDetectionRadius;

        public MeleeWeaponModel(MeleeWeaponData meleeWeaponData) : base(meleeWeaponData)
        {
            this.damage = meleeWeaponData.Damage;
            this.hitDetectionRadius = meleeWeaponData.HitDetectionRadius;
        }

        public override void Attack(List<IDamageable> enemiesInRange)
        {
            IDamageable closestEnemy = GetClosestEnemy(enemiesInRange);

            if (closestEnemy != null)
            {
                Debug.Log($"Melee Attack! Dealing {damage} damage to enemy at {closestEnemy.GetPosition()}");

                // Call Damage method on the enemy
                //closestEnemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("No enemy found to attack!");
            }
        }
    }
}