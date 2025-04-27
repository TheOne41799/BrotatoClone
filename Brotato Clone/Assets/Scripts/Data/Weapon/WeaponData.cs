using BrotatoClone.Weapon;
using UnityEngine;

namespace BrotatoClone.Data
{
    [CreateAssetMenu(menuName = "Game Data/ Weapon Data", fileName = "Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private MeleeWeaponView meleeWeaponViewPrefab;

        public MeleeWeaponView MeleeWeaponViewPrefab => meleeWeaponViewPrefab;
    }
}