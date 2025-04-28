using BrotatoClone.Common;
using BrotatoClone.Data;
using BrotatoClone.Enemy;
using UnityEngine;

namespace BrotatoClone.Weapon
{
    public class MeleeWeaponView : WeaponView
    {
        protected override void Update()
        {
            base.Update();
            RotateWeapon();
        }

        private void RotateWeapon()
        {
            // Example: Make the melee weapon face upwards by default
            Vector3 direction = Vector3.up;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Hardcoded rotation speed for now
        }
    }
}