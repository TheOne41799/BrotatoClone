using BrotatoClone.Weapon;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Weapon Data/ Test Weapon Data", fileName = "Test Weapon Data")]
    public class TestWeaponData : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private float enemyDetectionRange;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private LayerMask layerMask;

        [Header("DEBUG")]
        [SerializeField] protected bool isGizmosON;
        [Header("Prefabs")]
        [SerializeField] private TestWeaponView testWeaponViewPrefab;
        [Header("Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float hitDetectionRadius;
        [Header("Attack")]
        [SerializeField] private float attackRate;

        public TestWeaponView TestWeaponViewPrefab => testWeaponViewPrefab;
        public float Damage => damage;
        public float HitDetectionRadius => hitDetectionRadius;
        public WeaponType WeaponType => weaponType;
        public float EnemyDetectionRange => enemyDetectionRange;
        public float RotationSpeed => rotationSpeed;
        public LayerMask LayerMask => layerMask;
        public bool IsGizmosON => isGizmosON;
        public float AttackRate => attackRate;
    }
}
