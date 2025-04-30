using UnityEngine;

namespace BrotatoClone.Common
{
    public struct WeaponSpawnData
    {
        public Transform weaponTransform;

        public WeaponSpawnData(Transform weaponTransform)
        {
            this.weaponTransform = weaponTransform;
        }
    }

}