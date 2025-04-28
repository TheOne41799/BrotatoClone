using BrotatoClone.Common;
using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponController : WeaponController
    {
        /*public MeleeWeaponController(MeleeWeaponData weaponData) : base(weaponData) { }

        protected override IWeaponModel CreateModel(WeaponData weaponData)
        {
            MeleeWeaponData meleeWeaponData = weaponData as MeleeWeaponData;
            return new MeleeWeaponModel(meleeWeaponData);
        }

        protected override IWeaponView CreateView(WeaponData weaponData)
        {
            MeleeWeaponData meleeWeaponData = weaponData as MeleeWeaponData;
            return GameObject.Instantiate<MeleeWeaponView>(meleeWeaponData.MeleeWeaponViewPrefab);
        }

        public override void Attack()
        {
            //weaponModel.Attack();
        }

        public override void OnEnemiesDetected(List<IDamageable> enemies)
        {
            base.OnEnemiesDetected(enemies); 
        }*/
    }
}