using BrotatoClone.Common;
using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponModel : WeaponModel
    {
        private MeleeWeaponData meleeWeaponData;

        public MeleeWeaponModel(MeleeWeaponData meleeWeaponData)
        {
            this.meleeWeaponData = meleeWeaponData;
        }

        public override void Attack()
        {
            Debug.Log("Melee Weapon Attack triggered!");
        }
    }
}