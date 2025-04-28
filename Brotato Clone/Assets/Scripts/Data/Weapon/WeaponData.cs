using BrotatoClone.Weapon;
using UnityEngine;

namespace BrotatoClone.Data
{
    public abstract class WeaponData : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private float enemyDetecttionRange;

        public WeaponType WeaponType => weaponType;
        public float EnemyDetectionRange => enemyDetecttionRange;
    }
}