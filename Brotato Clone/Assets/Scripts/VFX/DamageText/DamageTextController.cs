using BrotatoClone.Data;
using UnityEngine;

namespace BrotatoClone.VFX
{
    public class DamageTextController
    {
        private DamageText damageText;

        public DamageTextController(VFXData vfxData)
        {
            damageText = GameObject.Instantiate<DamageText>(vfxData.DamageTextPrefab);
        }
    }
}