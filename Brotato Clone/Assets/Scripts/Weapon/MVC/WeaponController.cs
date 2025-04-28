using BrotatoClone.Common;
using BrotatoClone.Data;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponController : IWeaponController
    {
        /*protected IWeaponModel weaponModel;
        protected IWeaponView weaponView;

        public WeaponController(WeaponData weaponData)
        {
            this.weaponModel = CreateModel(weaponData);
            this.weaponView = CreateView(weaponData);
        }

        protected abstract IWeaponModel CreateModel(WeaponData weaponData);
        protected abstract IWeaponView CreateView(WeaponData weaponData);
        public abstract void Attack();
        public virtual void OnEnemiesDetected(List<IDamageable> enemies)
        {
            weaponModel.Attack(enemies);
        }

        public void OnUpdate()
        {
            weaponModel.OnUpdate();
        }*/


    }
}