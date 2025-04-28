using BrotatoClone.Common;
using System.Collections.Generic;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public interface IWeaponController
    {
        void Attack();
        void OnEnemiesDetected(List<IDamageable> enemies);
    }
}