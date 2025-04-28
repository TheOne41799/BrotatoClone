using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public abstract class WeaponModel : IWeaponModel
    {
        private float enemyDetectionRange;

        protected WeaponModel(WeaponData weaponData)
        {
            this.enemyDetectionRange = weaponData.EnemyDetectionRange;
        }
    }
}