using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.VFX
{
    public class DamageTextController
    {
        private DamageText damageText;

        public DamageTextController(VFXData vfxData, Vector2 spawnPosition)
        {
            damageText = GameObject.Instantiate<DamageText>(vfxData.DamageTextPrefab, spawnPosition, Quaternion.identity);
        }
    }
}