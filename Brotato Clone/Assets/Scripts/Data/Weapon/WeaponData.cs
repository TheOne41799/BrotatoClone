using BrotatoClone.Common;
using UnityEngine;

namespace BrotatoClone.Data
{
    public abstract class WeaponData : ScriptableObject
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private float enemyDetectionRange;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private LayerMask layerMask;

        [Header("DEBUG")]
        [SerializeField] protected bool isGizmosON;

        public WeaponType WeaponType => weaponType;
        public float EnemyDetectionRange => enemyDetectionRange;
        public float RotationSpeed => rotationSpeed;
        public LayerMask LayerMask => layerMask;
        public bool IsGizmosON => isGizmosON;
    }
}