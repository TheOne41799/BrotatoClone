using BrotatoClone.Weapon;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Weapon Data/ Melee Weapon Data", fileName = "Melee Weapon Data")]
    public class MeleeWeaponData : WeaponData
    {
        [Header("Prefabs")]
        [SerializeField] private MeleeWeaponView meleeWeaponViewPrefab;
        [Header("Stats")]
        [SerializeField] private float damage;
        [SerializeField] private float hitDetectionRadius;

        public MeleeWeaponView MeleeWeaponViewPrefab => meleeWeaponViewPrefab;
        public float Damage => damage;
        public float HitDetectionRadius => hitDetectionRadius;
    }
}