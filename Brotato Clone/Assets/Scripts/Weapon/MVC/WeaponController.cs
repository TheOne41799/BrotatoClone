using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponController : IWeaponController
    {
        protected IWeaponModel weaponModel;
        protected IWeaponView weaponView;

        public WeaponController(WeaponData weaponData)
        {
            this.weaponModel = CreateModel(weaponData);
            this.weaponView = CreateView(weaponData);
        }

        protected abstract IWeaponModel CreateModel(WeaponData weaponData);
        protected abstract IWeaponView CreateView(WeaponData weaponData);
        public abstract void Attack();
    }
}