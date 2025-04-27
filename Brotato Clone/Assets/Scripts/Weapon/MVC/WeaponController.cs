using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponController : IWeaponController
    {
        protected IWeaponModel weaponModel;
        protected IWeaponView weaponView;

        public abstract void Attack();
        public virtual void Reload() { }
    }
}