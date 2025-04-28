using BrotatoClone.Common;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public interface IWeaponModel
    {
        void Attack(List<IDamageable> enemiesInRange);
    }
}