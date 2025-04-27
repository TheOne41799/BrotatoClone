using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponController : WeaponController
    {
        public MeleeWeaponController(MeleeWeaponData meleeWeaponData)
        {
            weaponModel = new MeleeWeaponModel();
            weaponView = GameObject.Instantiate<MeleeWeaponView>(meleeWeaponData.MeleeWeaponViewPrefab);
        }

        public override void Attack()
        {
            Debug.Log("Attack");
        }
    }
}